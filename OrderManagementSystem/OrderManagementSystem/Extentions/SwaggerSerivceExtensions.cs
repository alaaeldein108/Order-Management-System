using Microsoft.OpenApi.Models;

namespace OrderManagementSystem.Extentions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) // Fix spelling
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer", // Fix typo
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearer", // Fix typo
                    }
                };
                options.AddSecurityDefinition("bearer", securitySchema); // Fix typo
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "bearer" } } // Fix typo
            });
            });
            return services;
        }
    }
}