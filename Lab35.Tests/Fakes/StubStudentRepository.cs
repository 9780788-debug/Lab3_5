using Lab35.DAL;
using Lab35.Models;

namespace Lab35.Tests.Fakes;

// Заглушка (stub): зберігає студентів у пам'яті замість файлу
public class StubStudentRepository : IStudentRepository
{
    // Дані "файлу" в пам'яті
    public List<Student> Data { get; } = new();

    public StubStudentRepository(params Student[] students)
    {
        Data.AddRange(students);
    }

    // Віддаємо копію, щоб тести не ламали дані
    public List<Student> LoadAll()
    {
        return Data.ToList();
    }

    public void SaveAll(IEnumerable<Student> students)
    {
        var copy = students.ToList();
        Data.Clear();
        Data.AddRange(copy);
    }
}
