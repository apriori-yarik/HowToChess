using DataAccess;
using DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class AppBuilderExtensions
    {
        public static async Task UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<HowToChessDbContext>();
            await context.Database.MigrateAsync();
            await SeedDataAsync(context);
        }

        private static async Task SeedDataAsync(HowToChessDbContext context)
        {
            await Seed.SeedRolesAsync(context);
        }
    }
}
