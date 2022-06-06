using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NumberOrdering.Repository.Data;
using NumberOrdering.Repository.Interfaces;
using NumberOrdering.Repository.Services;
using NumberOrdering.Services.Interfaces;
using NumberOrdering.Services.Services;

namespace NumberOrdering
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NumberOrdering", Version = "v1" });
            });

            services.AddDbContext<NumberOrderingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NumberOrderingDB")));

            SetUpDependencyInjection(services);
            SetUpEntityFramework(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NumberOrdering v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetUpDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IBusinessService, BusinessService>();
            services.AddTransient<INumberSorterService, NumberSorterService>();
            services.AddTransient<IFileService, FileService>();
        }

        private void SetUpEntityFramework(IServiceCollection services)
        {
            services.AddScoped<NumberOrderingContext>();
        }
    }
}
