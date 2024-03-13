using BlogDotNet8.Data;
using Microsoft.AspNetCore.Identity;

namespace BlogDotNet8.Extensions;

public static class AppExtension
{
    public static void SeedRole(this WebApplication app)
    {
        try
        {
            var scope = app.Services.CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            ctx.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");
            if (!ctx.Roles.Any())
            {
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            if (!ctx.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                var result = userManager.CreateAsync(adminUser, password: "password").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(adminUser, adminRole.Name!).GetAwaiter().GetResult();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
