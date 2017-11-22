using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Context;

namespace PhoneBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFContext>(builder =>
            {
                builder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = MVC3; Integrated Security = True");
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => routes.MapRoute("default",
                    "{controller=Person}/{action=Index}/{id?}"));
        }
    }
}
