using Bownty.Localisation;
using Bownty.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace Bownty.LocalisationAPI
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
            services.Configure<LocaliseConfig>(Configuration.GetSection(nameof(LocaliseConfig)));
            services
                .AddSingleton<LocaliseClient>()
                .AddSingleton<ILogger>(new BowntyLogger())
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            try
            {
                var lc = app.ApplicationServices.GetService<LocaliseClient>();
                var source = new CancellationTokenSource(100000);
                var token = source.Token;

                lc.Initialize(token).Wait();
            }
            catch (Exception ex)
            {
                var logger = app.ApplicationServices.GetService<ILogger>();
                logger.Log(LogLevel.Critical, ex, "Failed to download localisations");
            }
        }
    }
}
