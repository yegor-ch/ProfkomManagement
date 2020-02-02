using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfkomManagement.Data;
using ProfkomManagement.Data.Interfeces;
using ProfkomManagement.Data.Repositories;
using ProfkomManagement.Models;

namespace ProfkomManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ProfkomDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("ProfkomDbConnection"))
                .UseLazyLoadingProxies());

            
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Setting password rules.
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<ProfkomDbContext>();


            
            services.AddScoped<IMemberRepository, DbMembersRepository>();
            services.AddScoped<IFacultyRepository, DbFacultiesRepository>();
            services.AddScoped<IGroupRepository, DbGroupRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            });

        }
    }
}
