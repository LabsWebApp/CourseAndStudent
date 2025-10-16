namespace CourseAndStudentModels.Repositories;

public interface ICoursesRep
{
    //Read
    IEnumerable<Course> Items { get; }
    Course? GetCourseById(Guid id);

    //Delete
    void Delete(Guid id);

    //Update + Create
    void Update(Course student);
}