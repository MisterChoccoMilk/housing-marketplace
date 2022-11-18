using marketplace.Auth.Model;
using Microsoft.AspNetCore.Identity;

namespace marketplace.Data;

public class AuthDbSeeder
{
    private readonly UserManager<MarketplaceRestUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthDbSeeder(UserManager<MarketplaceRestUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        await AddDefaultRoles();
        await AddAdminUser();
    }

    private async Task AddAdminUser()
    {
        var newAdminUser = new MarketplaceRestUser()
        {
            UserName = "admin",
            Email = "ignarmis@gmail.com"
        };

        var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
        if (existingAdminUser == null)
        {
            var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "ArSlaptazodisStiprus123?");
            if (createAdminUserResult.Succeeded)
            {
                await _userManager.AddToRolesAsync(newAdminUser, MarketplaceRoles.All);
            }
        }
    }

    private async Task AddDefaultRoles()
    {
        foreach (var role in MarketplaceRoles.All)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
