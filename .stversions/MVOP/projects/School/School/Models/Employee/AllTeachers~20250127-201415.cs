using School.Models.Employee;
using System.Collections.ObjectModel;

namespace Teachers.Models;

internal class AllTeachers
{
    public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();

    public AllTeachers() =>
        LoadTeachers();

    public void LoadTeachers()
    {
        Teachers.Clear();

        // Get the folder where the teachers are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.teachers.txt files.
        IEnumerable<Teacher> teachers = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.teachers.txt")

                                    // Each file name is used to create a new Teacher
                                    .Select(filename => new Teacher()
                                    {
                                        Filename = filename,
                                        Name = File.ReadAllText(filename),
                                        UpdateDate = File.GetLastWriteTime(filename)
                                    })

                                    // With the final collection of teachers, order them by date
                                    .OrderBy(teacher => teacher.Name)
                                    .ThenBy(teacher => teacher.EmployeeId);

        // Add each teacher into the ObservableCollection
        foreach (Teacher teacher in teachers)
            Teachers.Add(teacher);
    }
}