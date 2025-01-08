using System.ComponentModel.DataAnnotations;

namespace ApiGastos.Dtos;

public record CategoryDto(Guid Id, string Name, string Description, DateTimeOffset CreatedDate);
public record CreateCategoryDto([Required] string Name, string Description);
public record UpdateCategoryDto([Required] string Name, string Description);