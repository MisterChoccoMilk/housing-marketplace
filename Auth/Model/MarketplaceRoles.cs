namespace marketplace.Auth.Model;

public static class MarketplaceRoles
{
    public const string Admin = nameof(Admin);
    public const string MarketplaceUser = nameof(MarketplaceUser);

    public static readonly IReadOnlyCollection<string> All = new[] { Admin, MarketplaceUser };
}
