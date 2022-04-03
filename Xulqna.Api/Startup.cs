using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Xulqna.Data.Contexts;
using Xulqna.Data.IRepositories;
using Xulqna.Data.Repositories;
using Xulqna.Service.Helpers;
using Xulqna.Service.Interfaces;
using Xulqna.Service.Services;

namespace Xulqna.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<XulqnaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Xulqna"));
            });


            services.AddHttpContextAccessor();

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xulqna.Api", Version = "v1" });
            });

            // custom services
            services.AddScoped<IStudentRepository, StudentRepostitory>();
            services.AddScoped<IGroupRepository, GroupRepository>();


            services.AddScoped<IStudentService, StudentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xulqna.Api v1"));
            }

           if( app.ApplicationServices.GetService<IHttpContextAccessor>() is not null)
            {
                HttpContextHelper.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
