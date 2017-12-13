using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGroup.configs;
using StudentGroup.StudentsDB;

namespace StudentGroup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string DBConnectionString =
            "Server=(localdb)\\mssqllocaldb;" +
            "Database=StudentsDb;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=true;";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Requisites>(Configuration.GetSection("Requisites"));
            services.AddScoped<IStudentsDatabase,StudentsDatabase>();
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(DBConnectionString));
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Group}/{action=GetStudents}");
            });
        }
    }
}
