using System.Threading.Channels;
using Microsoft.Extensions.Options;

namespace CourseAndStudentEfModels;

static class DbInitializer
{
    /// <summary>
    /// Универсальная инициализация базы: миграции, если они есть, иначе EnsureCreated.
    /// </summary>
    public static void Initialize(AppContext context)
    {
        try
        {
            // Проверяем, есть ли какие-нибудь миграции в проекте
            IEnumerable<string>? pendingMigrations = context.Database.IsRelational() ? 
                context.Database.GetPendingMigrations() : null;

            if (pendingMigrations != null && pendingMigrations.Any())
            {
                Console.WriteLine("Применение миграций...");
                context.Database.Migrate();
            }
            else 
            {
                Console.WriteLine("Миграций нет. Используем EnsureCreated...");
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SeedData(context);
                foreach (var name in TableNames(context))
                    Console.WriteLine($"******\n{name}\n");
            }

            Console.WriteLine("База инициализирована!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка инициализации базы: {ex.Message}");
            throw;
        }
    }

    private static void SeedData(AppContext context)
    {
        for (var i = 1; i < 50; i++)
            context.Students
                .Add(new Student { Name = $"Student_{i}" });
        context.SaveChanges();

        var random = new Random();
        for (var i = 1; i <= 10; i++)
        {
            var course = new Course { Name = $"Course_{i}" };
            var r = random.Next(0, 12);
            
            var list = new List<Student>();
            course.Students.AddRange( 
                context.Students.GetRandomElements(r));
            context.Courses.Add(course);
        }

        context.SaveChanges();
    }

    private static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
    {
        var random = new Random();
        var available = list.ToList();
        var selected = new List<T>();

        for (var i = 0; i < elementsCount && available.Count > 0; i++)
        {
            var index = random.Next(available.Count);
            selected.Add(available[index]);
            available.RemoveAt(index);
        }

        return selected;
    }

    private static IList<string?> TableNames(DbContext context) =>
        context.Model.GetEntityTypes()
            .Select(t => t.GetTableName())
            .Where(name => !string.IsNullOrEmpty(name))
            .Distinct()
            .ToList();
}