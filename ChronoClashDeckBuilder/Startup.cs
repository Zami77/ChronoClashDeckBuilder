using ChronoClashDeckBuilder.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Session;


namespace ChronoClashDeckBuilder
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

            services.AddDbContext<Models.ChronoClashDbContext>(options =>
                options.UseSqlServer(Configuration["Data:ChronoClashCards:ChronoClashAzure"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ChronoClashDbContext>();
            services.AddScoped<ChronoClashDeckBuilder.Models.ICardRepository, ChronoClashDeckBuilder.Models.EFCardRepository>();
            services.AddScoped<ChronoClashDeckBuilder.Models.IDeckRepository, ChronoClashDeckBuilder.Models.EFDeckRepository>();
            services.AddScoped<CurDeck>(sp => SessionDeck.GetCurDeck(sp));
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //using (var scope =
            //    app.ApplicationServices.CreateScope())
            //using (var context = scope.ServiceProvider.GetService<ChronoClashDbContext>())
            //    context.Database.Migrate();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
