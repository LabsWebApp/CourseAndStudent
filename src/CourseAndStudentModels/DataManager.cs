namespace CourseAndStudentModels;

public class DataManager(
    ICoursesRep courses, IStudentsRep students)
{
    public ICoursesRep Courses { get; } = courses;
    public IStudentsRep Students { get; } = students;
}