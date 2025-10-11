namespace CourseAndStudentModels.Repositories;

public interface IStudentsRep
{
    IEnumerable<Student> Items { get; }
    Student? GetStudentById(Guid id);
    void Delete(Guid id);
    void Update(Student  student);
}