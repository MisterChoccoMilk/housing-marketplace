namespace marketplace.Data.Dtos
{
    public record AdDto(int Id, string Name, string Description);
    public record CreateAdDto(string Name, string Description);
    public record UpdateAdDto(string Description);
}
