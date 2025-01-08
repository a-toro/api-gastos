
namespace ApiGastos.Entities;

public class ExpenseCategory : IEntity, ICategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}