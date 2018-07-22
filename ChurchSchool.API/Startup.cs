using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

namespace ChurchSchool.API
{
    public class Startup
    {
        private readonly string _secretKey; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey;

        private Info _apiInfo;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiInfo = SwaggerInfoHelper.GetSwaggerInformation();
            _secretKey = configuration.GetSection("SecretKey")?.Value;
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                ExpirationTimeInMinutes = int.Parse(_configuration.GetSection("JwtIssuerOptions").GetSection("ExpireTimeInMinutes").Value)
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
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Student", policy => policy.RequireClaim("Student"));
                options.AddPolicy("Teacher", policy => policy.RequireClaim("Teacher"));
                options.AddPolicy("PeopleManager", policy => policy.RequireClaim("PeopleManager"));
                options.AddPolicy("CourseManager", policy => policy.RequireClaim("CourseManager"));
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

            //Identity DI
            services.AddScoped<IAuthorization, Authorization>();
            services.AddScoped<IJwtFactory, JwtFactory>();

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

            

            //Unit of Work | TODO- Improve this part (shoul have a factory method responsible to provide a correct instance)
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkIdentity, UnitOfWorkIdentity>();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
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

            app.UseAuthentication();
            app.UseCors((builder) =>
            {
                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
