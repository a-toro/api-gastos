namespace ApiGastos.Entities;
public interface ICategory : IEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public DateTimeOffset CreatedDate { get; set; }
}