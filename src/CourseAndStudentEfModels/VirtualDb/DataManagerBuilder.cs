using CourseAndStudentEfModels.EfBase;
using CourseAndStudentModels;

namespace CourseAndStudentEfModels.VirtualDb;

public static class VirtualDataManagerBuilder
{
    private static DataManager? _dataManager;

    public static DataManager DataManager
    {
        get
        {
            if (_dataManager is not null) return _dataManager;

            var context = new VirtualDbContext();
            
            DbInitializer.Initialize(context);
            _dataManager = new(
                new CoursesEfBase { Context = context },
                new StudentsEfBase { Context = context });
            return _dataManager;
        }
    }
}