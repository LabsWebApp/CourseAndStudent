namespace CourseAndStudentModels.Repositories;

public interface ICoursesRep
{
    IEnumerable<Course> Items { get; }
    Course? GetCourseById(Guid id);
    void Delete(Guid id);
    void Update(Course student);
}