using Flo.FinishingMaster.Data;
using Flo.FinishingMaster.Data.Repository;
using Flo.FinishingMaster.Data.Services;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Repositories;
using Flo.FinishingMaster.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Flo.FinishingMaster
{
    public class Startup
    {
        public IConfiguration AppConfiguration;
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            AppConfiguration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(AppConfiguration.GetConnectionString("Default")));
            services.AddIdentityCore<User>().AddEntityFrameworkStores<DataContext>();


            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IWallRepository, WallRepository>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IApartmentService, ApartmentService>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                dataContext.Database.Migrate();

            }


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finishing Master API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
