namespace CourseAndStudentEfModels;

internal abstract class AppContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }

    protected string? ConnectionString { get; init; }
}