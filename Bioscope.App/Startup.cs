using System.Text;
using AutoMapper;
using Bioscope.App.Helpers;
using Bioscope.App.Seeds;
using Bioscope.Data;
using Bioscope.Data.Repositories;
using Bioscope.Infrastructure;
using Bioscope.Service.Abstraction;
using Bioscope.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bioscope.App
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
      services.AddRouting(option => option.LowercaseUrls = true);
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => false;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        // .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
        .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
      services.AddCors();
      services.AddTransient<Seed>();
      services.AddHttpClient<HttpService>();
      services.AddAutoMapper();
      services.AddDbContext<DataContext>(options => options.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("DataContext")));
      services.Configure<ApiConfig>(Configuration.GetSection("ApiConfig"));
      services.Configure<Middleware>(Configuration.GetSection("Middleware"));
      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)
          ),
          ValidateIssuer = false,
          ValidateAudience = false
          };
        });

      services.AddScoped<IDbFactory<DataContext>, DbFactory<DataContext>>();
      services.AddScoped<IUnitOfWork, UnitOfWork<DataContext>>();

      services.AddScoped<IDropdownRepository, DropdownRepository>();
      services.AddScoped<IDropdownService, DropdownService>();

      services.AddScoped<IRoleRepository, RoleRepository>();
      services.AddScoped<IRoleService, RoleService>();

      services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
      services.AddScoped<IAuthenticationService, AuthenticationService>();

      services.AddScoped<IFeatureRepository, FeatureRepository>();
      services.AddScoped<IFeatureService, FeatureService>();

      services.AddScoped<IMenuRepository, MenuRepository>();
      services.AddScoped<IMenuService, MenuService>();

      services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
      services.AddScoped<ISubscriptionService, SubscriptionService>();

      services.AddScoped<ICityRepository, CityRepository>();
      services.AddScoped<ICityService, CityService>();

      services.AddScoped<IRoleFeatureRepository, RoleFeatureRepository>();
      services.AddScoped<IRoleFeatureService, RoleFeatureService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      seeder.Run();
      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "areas",
          template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
      });
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });

    }
  }
}