using AutoMapper;
using FeedAggregator.BLL.Interfaces;
using FeedAggregator.BLL.MappingProfiles;
using FeedAggregator.BLL.Services;
using FeedAggregator.DAL;
using FeedAggregator.DAL.Data;
using FeedAggregator.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            ConfigureAutomapper(services);

            services.AddDbContext<FeedAggregatorDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        b => b.MigrationsAssembly("FeedAggregator.DAL")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IFeedService, FeedService>();
            services.AddTransient<IUserCollectionService, UserCollectionService>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FeedAggregatorDbContext>())
                {
                    context?.Database?.Migrate();
                }
            }

            app.UseMvc();
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
