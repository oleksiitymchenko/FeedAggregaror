using AutoMapper;
using FeedAggregaror_API.TasksSheduler;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.BLL.MappingProfiles;
using FeedAggregator.BLL.Providers.Logger;
using FeedAggregator.BLL.Services;
using FeedAggregator.DAL;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Interfaces;
using FeedParser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz.Spi;
using System.IO;

namespace FeedAggregaror
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureAutomapper(services);

            services.AddDbContext<FeedAggregatorDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        b => b.MigrationsAssembly("FeedAggregator.DAL")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddTransient<ItemsParser>();
            services.AddTransient<IFeedService, FeedService>();
            services.AddTransient<IUserCollectionService, UserCollectionService>();

            ConfigureBackgroundJobs(services);
            ConfigureLogger(services, new LoggerFactory());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FeedAggregatorDbContext>())
                {
                    context?.Database?.Migrate();
                }
            }

            app.UseQuartz((quartz) =>
            {
                quartz.AddJob<RefreshFeedJob>("RefreshFeed5MinutesJob", "DataRefresher", 15);                
            });
        }

        public virtual void ConfigureLogger(IServiceCollection services, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLoger");
            services.AddSingleton<ILogger>(logger);
        }

        public virtual IServiceCollection ConfigureBackgroundJobs(IServiceCollection services)
        {
            services.AddTransient<RefreshFeedJob>();

            services.AddTransient<IJobFactory, JobFactory>(
               (provider) =>
               {
                   return new JobFactory(provider);
               });

            return services;
        }

        public virtual IServiceCollection ConfigureAutomapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserCollectionProfile>();
                cfg.AddProfile<FeedProfile>();
                cfg.AddProfile<FeedItemProfile>();
            });

            return services;
        }
    }
}
