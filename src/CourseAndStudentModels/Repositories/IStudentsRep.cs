namespace CourseAndStudentModels.Repositories;

public interface IStudentsRep
{
    //Read
    IEnumerable<Student> Items { get; }
    Student? GetStudentById(Guid id);

    //Delete
    void Delete(Guid id);

    //Update + Create
    void Update(Student  student);
}