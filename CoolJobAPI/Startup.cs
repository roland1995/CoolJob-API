using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CoolJobAPI.Models;

namespace CoolJobAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Access-Control-Allow-Origin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                .WithMethods("PUT", "DELETE", "GET", "POST")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            }); 


            services.AddDbContext<JobContext>(opt =>
                                               opt.UseInMemoryDatabase("JobList")); 
            services.AddDbContext<FavoriteContext>(opt =>
                                                opt.UseInMemoryDatabase("FavoriteList"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
