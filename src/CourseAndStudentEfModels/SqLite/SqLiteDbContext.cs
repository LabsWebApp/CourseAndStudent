namespace CourseAndStudentEfModels.SqLite;

internal class SqLiteDbContext : AppContext
{
    public SqLiteDbContext() : base() =>
        ConnectionString = "Data Source=data.db";
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) =>
        optionBuilder.UseSqlite(ConnectionString);
}