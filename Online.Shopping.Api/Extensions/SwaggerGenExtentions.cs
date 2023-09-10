using Microsoft.OpenApi.Models;

namespace Online.Shopping.Api.Extensions
{
    public static class SwaggerGenExtentions
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineShoppingApi", Version = "v1" });

                // Configure Swagger to use Auth0 JWT Bearer Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        new string[] { }
                    },
                });
            });

            return serviceCollection;
        }

    }
}
