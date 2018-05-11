using ChurchSchool.API.Models;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ChurchSchool.API
{
    public class Startup
    {
        private Info _apiInfo;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _apiInfo = SwaggerInfoHelper.GetSwaggerInformation();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(
                   options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"))
               );

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeHistoryRepository, GradeHistoryRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ICourseConfigurationRepository, CourseConfigurationRepository>();
            services.AddScoped<ICurriculumRepository, CurriculumRepository>();
            services.AddScoped<IFrequencyRepository, FrequencyRepository>();
            
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", _apiInfo);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                
                c.SwaggerEndpoint("/swagger/v1/swagger.json", _apiInfo.Title);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

