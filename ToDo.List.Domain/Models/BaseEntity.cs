namespace ToDo.List.Domain.Domain;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }
}
