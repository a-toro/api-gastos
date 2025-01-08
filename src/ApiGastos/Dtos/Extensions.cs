using ApiGastos.Entities;

namespace ApiGastos.Dtos;

public static class Extensions
{
    public static CategoryDto AsDto(this ICategory category)
    {
        return new CategoryDto(category.Id, category.Name, category.Description, category.CreatedDate);
    }
}