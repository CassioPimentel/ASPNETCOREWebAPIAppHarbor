using ASPNETCOREWebAPIAppHarbor.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCOREWebAPIAppHarbor
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

            services.AddDbContext<Context>(options =>
                   options.UseMySQL("server=3ac74848-67ac-48fe-a97b-a86801128e1f.mysql.sequelizer.com;database=db3ac7484867ac48fea97ba86801128e1f;uid=akavrbhyrtgvzhcm;pwd=zdfwYzv8itTkbA4vuDHgHK8s7ejLcRZNVKkCdLcHdbQvrh7oZ3CzQ74WdUyUpR6y"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
