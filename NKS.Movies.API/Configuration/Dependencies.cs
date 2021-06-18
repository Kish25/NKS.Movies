namespace NKS.Movies.API.Configuration
{
    using Handlers;
    using Infrastructure.Repository;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    public static class Dependencies
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var swaggerConfig = config.GetSection("SwaggerConfiguration").Get<Swagger>();
            services.Configure<MoviesConfiguration>(config.GetSection(nameof(MoviesConfiguration)));

            services.AddMvcCore();
            services.AddTransient<IDbConnection>(sp => GetDbConnection(config["ConnectionStrings:MoviesDatabase"]));

            services.AddScoped<IUserService, UserService>()
                    .AddTransient<IMovieRepository,MovieRepository>();
            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlCommentsPath);
                options.SwaggerDoc($"v{swaggerConfig.Version}", new OpenApiInfo
                {
                    Title = swaggerConfig.Title,
                    Version = $"v{swaggerConfig.Version}",
                    Description = swaggerConfig.Description,

                });
                options.EnableAnnotations();
                options.AddSecurityDefinition("basic", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Basic Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        }

                    },new List<string>()
                    }
                });
            });


            return services;
        }

        private static SqlConnection GetDbConnection(string connectionString)
        {
            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }
    }

}
