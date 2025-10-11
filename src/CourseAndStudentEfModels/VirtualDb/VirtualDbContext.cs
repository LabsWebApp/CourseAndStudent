namespace CourseAndStudentEfModels.VirtualDb;

public class VirtualDbContext : AppContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) =>
        optionBuilder.UseInMemoryDatabase("CourseAndStudent");
}