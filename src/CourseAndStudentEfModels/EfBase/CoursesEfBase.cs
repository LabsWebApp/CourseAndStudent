namespace CourseAndStudentEfModels.EfBase;

public class CoursesEfBase : ICoursesRep
{
    public AppContext Context { private get; init; } = null!;

    public IEnumerable<Course> Items => Context.Courses;

    public void Delete(Guid id)
    {
        if (Context
                .Courses
                .Include(c => c.Students) // Загружаем связанных студентов
                .SingleOrDefault(c => c.Id == id) is not { } existing) return;

        // Удаляем связи
        foreach (var student in existing.Students.ToList()) existing.Students.Remove(student);

        Context.Courses.Remove(existing);
        Context.SaveChanges();
    }

    public Course? GetCourseById(Guid id) =>
        Context.Courses.SingleOrDefault(i => i.Id == id);

    public void Update(Course course)
    {
        switch (Context.Courses.SingleOrDefault(
                    i => i.Id == course.Id))
        {
            case null:
                Context.Courses.Add(course);
                break;
            default:
                Context.Courses.Update(course);
                break;
        }

        Context.SaveChanges();
    }
}
