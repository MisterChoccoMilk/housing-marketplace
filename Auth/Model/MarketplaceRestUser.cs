using Microsoft.AspNetCore.Identity;

namespace marketplace.Auth.Model;

public class MarketplaceRestUser : IdentityUser
{
    [PersonalData]
    public string? AdditionalInfo { get; set; }
}
