using Data.Context;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace OrderManagementSystem.Extentions
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<AppDbContext>();

                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager= services.GetRequiredService<RoleManager<ApplicationRole>>();
                    logger.LogInformation("Applying migrations...");

                    logger.LogInformation("Seeding users...");
                    await AddIdentityContextSeed.SeedUserAsync(userManager,roleManager);
                    logger.LogInformation("User seeding completed.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred during seeding");
                }
            }
        }
    }

}

