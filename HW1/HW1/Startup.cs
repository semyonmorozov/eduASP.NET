using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Routing;

namespace HW1
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
            services.AddMvc();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use((context, next) =>
            {
                context.Response.WriteAsync("This page loads with a random delay, refresh to check. \n");
                return next();
            });
                app.Use(async (context, next) =>
            {
                context.Response.WriteAsync("\tThis text from MW made with Lambda Expression. \n");
                Stopwatch st = new Stopwatch();
                st.Start();
                await next();
                st.Stop();
                context.Response.WriteAsync("\tDelay calculated in lambda MW: " + st.Elapsed.ToString()+"\n");
            });
            app.UseMyMW();
            app.Use((context, next) =>
            {
                int delay = new Random().Next(2000, 7000);
                context.Response.WriteAsync("\t\t\tReal delay: "+delay+"ms\n");
                return Task.Delay(delay);
            });
        }
    }
}
