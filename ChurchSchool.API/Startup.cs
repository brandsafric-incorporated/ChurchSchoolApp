using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using System.Reflection;
using System.Text;
using System;

using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Newtonsoft.Json;

using ChurchSchool.Application.Contracts;
using ChurchSchool.Application;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Repository.UOW;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.API.Models;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Repositories;
using ChurchSchool.Identity.Model;
using ChurchSchool.Identity.Contracts;
using ChurchSchool.Identity;
using ChurchSchool.Shared;
using ChurchSchool.Identity.Entities;
using ChurchSchool.Service.Implementations;
using ChurchSchool.Service.Contracts;
using ChurchSchool.Application.App;
using System.Security.Claims;
using Newtonsoft.Json.Serialization;

namespace ChurchSchool.API
{
    public class Startup
    {
        private readonly string _secretKey; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey;
        private readonly IHostingEnvironment _environment;

        private Info _apiInfo;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _apiInfo = SwaggerInfoHelper.GetSwaggerInformation();
            _secretKey = configuration.GetSection("SecretKey")?.Value;
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            _environment = environment;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //Razor View Renderer
            services.AddScoped<IViewRenderService, ViewRenderService>();
            var viewAssembly = typeof(EmailService).GetTypeInfo().Assembly;
            var fileProvider = new EmbeddedFileProvider(viewAssembly);

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(fileProvider);
            });

            //Configuratons
            services.Configure<ApplicationSettings>(_configuration);

            //DB
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("LocalConnection"), x => x.MigrationsAssembly("ChurchSchool.Repository"));
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("LocalConnection"), x => x.MigrationsAssembly("ChurchSchool.Repository"));
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            });

            var jwtSettings = _configuration.GetSection(nameof(JwtIssuerOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtSettings[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            JwtIssuerOptions.jwtIssuerOptions = new JwtIssuerOptions
            {
                ExpirationTimeInMinutes = int.Parse(_configuration.GetSection("JwtIssuerOptions")
                                                                  .GetSection("ExpireTimeInMinutes").Value)
            };

            //JWT-CONFIGURATION
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtSettings[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtSettings[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;                
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = jwtSettings[nameof(JwtIssuerOptions.Issuer)];
                options.TokenValidationParameters = tokenValidationParameters;
                options.SaveToken = true;
                options.IncludeErrorDetails = true;
                options.Validate();
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("school-manager", policy => policy.RequireClaim(ClaimTypes.Role, "manager"));
                options.AddPolicy("teacher", policy => policy.RequireClaim(ClaimTypes.Role, "teacher"));
                options.AddPolicy("student", policy => policy.RequireClaim(ClaimTypes.Role, "student"));
                options.AddPolicy("logged-person", policy => policy.RequireClaim(ClaimTypes.Role, new string[] { "manager", "teacher", "student", "staff"}));
                options.AddPolicy("administrative-person", policy => policy.RequireClaim(ClaimTypes.Role, new string[] { "manager", "staff" }));
                options.AddPolicy("people-manager", policy => policy.RequireClaim(ClaimTypes.Role, new string[] { "manager", "staff" }));
            });

            //Mapper
            services.AddAutoMapper();

            //Application DI
            services.AddScoped<ICourse, Course>();
            services.AddScoped<ICourseClass, CourseClass>();
            services.AddScoped<ICourseConfiguration, CourseConfiguration>();
            services.AddScoped<IEnrollment, Enrollment>();
            services.AddScoped<ICurriculum, Curriculum>();
            services.AddScoped<ISubject, Subject>();
            services.AddScoped<IPerson, Person>();
            services.AddScoped<IStudent, Student>();
            services.AddScoped<IProfessor, Professor>();
            services.AddScoped<IAccount, Account>();
            services.AddScoped<ISchool, School>();
            services.AddScoped<ICurriculumConfiguration, CurriculumConfiguration>();

            //Identity DI
            services.AddScoped<IAuthorization, Authorization>();
            services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddScoped<IPasswordRecovery, PasswordRecovery>();

            //Repository DI            
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseConfigurationRepository, CourseConfigurationRepository>();
            services.AddScoped<ICurriculumRepository, CurriculumRepository>();
            services.AddScoped<ICurriculum_SubjectRepository, Curriculum_SubjectRepository>();
            services.AddScoped<ICourseDocumentRepository, CourseDocumentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICourseClassRepository, CourseClassRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IProfessorSubjectRepository, ProfessorSubjectRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ICurriculumConfigurationRepository, CurriculumConfigurationRepository>();

            //Application Services
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailTemplateService, EmailTemplateService>();

            //Unit of Work | TODO- Improve this part (shoul have a factory method responsible to provide a correct instance)
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkIdentity, UnitOfWorkIdentity>();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", _apiInfo));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", _apiInfo.Title));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseCors((builder) =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
