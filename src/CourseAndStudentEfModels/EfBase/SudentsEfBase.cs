namespace CourseAndStudentEfModels.EfBase;

public class StudentsEfBase : IStudentsRep
{
    public AppContext Context { private get; init; } = null!;

    public IEnumerable<Student> Items => Context.Students;

    public void Delete(Guid id)
    {
        if (Context
                .Students
                .Include(c => c.Courses) // Загружаем связанных студентов
                .SingleOrDefault(c => c.Id == id) is not { } existing) return;

        // Удаляем связи
        foreach (var course in existing.Courses.ToList()) existing.Courses.Remove(course);

        Context.Students.Remove(existing);
        Context.SaveChanges();
    }

    public Student? GetStudentById(Guid id) =>
        Context.Students.SingleOrDefault(i => i.Id == id);

    public void Update(Student student)
    {
        if (Context.Students.SingleOrDefault(
                i => i.Id == student.Id) == null)
            Context.Students.Add(student);
        else
            Context.Students.Update(student);

        Context.SaveChanges();
    }
}
