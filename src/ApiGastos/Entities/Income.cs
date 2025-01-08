namespace ApiGastos.Entities;

public class Income : IEntity
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public Guid CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}