using Data;
using Data.Entities;
using FluentValidation.AspNetCore;
using FragranceShopApi.Authorization;
using FragranceShopApi.Extensions;
using FragranceShopApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FragranceShopApi
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
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);
            services.AddMemoryCache();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                };
            });

            ///Examples
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality"));
            //    options.AddPolicy("Atleast20", builder => builder.AddRequirements(new MinimumAgeRequirement(20)));
            //});

            services.AddAuthorizationServices();

            services.AddControllers().AddFluentValidation();
            services.AddDbContext<PerfumeDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("PerfumeDbConnection")));
            services.AddScoped<PerfumesShopDbSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddConventionalServices();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddValidatorServices();
     
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", builder =>
                {
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.WithOrigins(Configuration["AllowedOrigins"]);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PerfumesShopDbSeeder seeder)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = preparation => preparation.UseCacheForStaticFiles(days: 10)
            });

            app.UseResponseCaching();
            app.UseCors("FrontEndClient");

            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Perfume shop API");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
