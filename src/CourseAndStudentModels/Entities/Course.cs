namespace CourseAndStudentModels.Entities;

public class Course : EntityBase
{
    public List<Student> Students { get; set; } = [];

    public override string ToString()
    {
        var res = base.ToString();

        if (Students.Any())
            res = Students
                .Aggregate(
                    res + "\nStudents:", (current, item) =>
                        current + $"\n\tName: {item.Name}");
        return res;
    }
}