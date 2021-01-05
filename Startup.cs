using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenMed.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DenMed.Repositories;

namespace DenMed
{
    public class Startup
    {        

        public Startup(IConfiguration configuration) => Configuration = configuration;


        public IConfiguration Configuration { get; set;}
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("DenMedConnectionString")
            ));

            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<IReservationRepo, ReservationRepo>();
            services.AddTransient<ISpecialistRepo, SpecialistRepo>();
            services.AddTransient<ISurgeryRepo, SurgeryRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults : new {controller="Home", action="Index"}
                );
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}"                    
                );

                routes.MapRoute(
                    name: null,
                    template: "{controller}",
                    defaults: new {action="Index"}
                );

                
            });

            // AppDbContext context = app.ApplicationServices
            //     .GetRequiredService<AppDbContext>();
            // context.Database.Migrate();

            
        }
    }
}
