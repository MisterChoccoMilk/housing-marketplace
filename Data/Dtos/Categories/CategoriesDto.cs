﻿namespace marketplace.Data.Dtos
{
    public record CategoryDto(int Id, string Name, string Description);
    public record CreateCategoryDto(string Name, string Description);
    public record UpdateCategoryDto(string Description);

}
