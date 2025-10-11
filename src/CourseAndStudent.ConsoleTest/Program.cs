using CourseAndStudentEfModels.VirtualDb;

var data = VirtualDataManagerBuilder.DataManager;

foreach (var item in data.Students.Items) Console.WriteLine(item);

foreach (var item in data.Courses.Items) Console.WriteLine(item);

Console.ReadKey();

data.Courses.Delete(data.Courses.Items.Last().Id);

Console.WriteLine("\n\n#######################################\n\n");

foreach (var item in data.Students.Items) Console.WriteLine(item);

foreach (var item in data.Courses.Items) Console.WriteLine(item);

Console.ReadKey();
