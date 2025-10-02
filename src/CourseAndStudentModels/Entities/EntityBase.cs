namespace CourseAndStudentModels.Entities;

public abstract class EntityBase
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
}