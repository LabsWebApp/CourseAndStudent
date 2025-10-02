namespace CourseAndStudentModels.Entities;

public class Course : EntityBase
{
    public IEnumerable<Student> Students { get; set; } = new List<Student>();
}