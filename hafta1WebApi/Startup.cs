using hafta1WebApi.DBOperations;
using hafta1WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hafta1WebApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hafta1WebApi", Version = "v1" });
            });
            services.AddDbContext<TaskDbContext>(options => options.UseInMemoryDatabase(databaseName: "TaskDB"));
            services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase(databaseName: "UserDB"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hafta1WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            //Kendi middleware katmanım Task kısmında patch içine olayan bir id (23 ) yollayıp test edilebilir.
            app.UseCustomExceptionMidde();



            //app.MapWhen(x => x.Request.Path == "/api/Task", internalApp =>
            
            //    internalApp.Use(async (context, next) =>
            //    {
            //        Console.WriteLine("Task Apileri kullanılıyor!");

            //        await context.Response.WriteAsync(" Task Api's in use ");
                    
            //    })
            //);
            //app.Map("/api/User", internalApp =>
            //internalApp.Use(async (context, next) =>
            //{
            //    Console.WriteLine("User Apileri kullanılıyor!");


            //    await next.Invoke();
            //}));

           
           app.UseEndpoints(endpoints =>
            {

                 endpoints.MapControllers();

            });
               





        }
    }
}
