namespace CourseAndStudentModels.Entities;

public class Student : EntityBase
{
    public IEnumerable<Course> Courses { get; set; } = new List<Course>();
}