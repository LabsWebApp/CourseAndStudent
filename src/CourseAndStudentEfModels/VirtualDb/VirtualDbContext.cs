namespace CourseAndStudentEfModels.VirtualDb;

internal class VirtualDbContext : AppContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) =>
        optionBuilder.UseInMemoryDatabase("CourseAndStudent");
}