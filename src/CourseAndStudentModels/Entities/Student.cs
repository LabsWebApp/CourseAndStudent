namespace CourseAndStudentModels.Entities;

public class Student : EntityBase
{
    public List<Course> Courses { get; set; } = [];

    public override string ToString()
    {
        var res = base.ToString();

        if (Courses.Any())
            res = Courses
                .Aggregate(
                    res + "\nCourses:", (current, item) =>
                        current + $"\n\tName: {item.Name}");
        return res;
    }
}