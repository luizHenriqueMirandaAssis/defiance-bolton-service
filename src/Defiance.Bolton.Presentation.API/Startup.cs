using Defiance.Bolton.Infrastructure.Data.Context;
using Defiance.Bolton.Infrastructure.Ioc;
using Defiance.Bolton.Presentation.API.Configurations;
using Defiance.Bolton.Presentation.API.Swagger;
using Defiance.Bolton.Presentation.API.Tasks.Interfaces;
using Defiance.Bolton.Presentation.API.Tasks.Services;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Defiance.Bolton.Presentation.API
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
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGeneration();
            services.AddApiVersioningAndExplorer();
            services.AddHangfire(config => config.UseMemoryStorage());
            services.AddControllers();

            services.AddTransient<IIntegrationTask, IntegrationTask>();
            NativeInjectorBootStrapper.AddIoC(services);

            services.AddDbContext<DefianceBoltonContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(10)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() }
            });

            var backgroundJobServerOptions = new BackgroundJobServerOptions
            {
                Activator = new ContainerJobActivator(app.ApplicationServices),
                Queues = new[] { "integration" }
            };

            app.UseHangfireServer(backgroundJobServerOptions);
            ActivatorUtilities.CreateInstance<SchedulerConfig>(app.ApplicationServices).RunTasks();

            app.UseSwagger();
            app.UseSwaggerUIAndAddApiVersionEndPointBuilder(provider);
        }
    }
}
