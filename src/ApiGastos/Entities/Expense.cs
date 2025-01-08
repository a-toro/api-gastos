namespace ApiGastos.Entities;

public class Expense : IEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public Guid CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}