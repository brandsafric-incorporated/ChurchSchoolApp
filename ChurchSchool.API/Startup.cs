using ChurchSchool.API.Models;
using ChurchSchool.Application;
using ChurchSchool.Application.App;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository.Repositories;
using ChurchSchool.Repository.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace ChurchSchool.API
{
    public class Startup
    {
        private Info _apiInfo;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiInfo = SwaggerInfoHelper.GetSwaggerInformation();
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("LocalConnection"));
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            });

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

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", _apiInfo));

            services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.Authority = "http://locahost:5000";
                options.MetadataAddress = "http://localhost:5000/.well-known/openid-configuration";
                options.RequireHttpsMetadata = false;
                options.Audience = "ChurchSchoolApi";
            });
            //.AddIdentityServerAuthentication(options =>
            //{
            //    options.Authority = "http://locahost:5000";
            //    options.RequireHttpsMetadata = false;
            //    options.ApiName = "ChurchSchoolApi";                
            //});
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

            app.UseMvc();
        }
    }
}
