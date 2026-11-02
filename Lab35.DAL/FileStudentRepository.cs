using System.Text.Encodings.Web;
using System.Text.Json;
using Lab35.Models;

namespace Lab35.DAL;

// Зберігання студентів у JSON-файлі
public class FileStudentRepository : IStudentRepository
{
    // Налаштування JSON: відступи і нормальна кирилиця
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    // Шлях до файлу
    private readonly string _path;

    public FileStudentRepository(string path)
    {
        _path = path;
    }

    public List<Student> LoadAll()
    {
        // Файлу ще немає - список порожній
        if (!File.Exists(_path)) return new List<Student>();

        // Читаємо файл і десеріалізуємо
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    public void SaveAll(IEnumerable<Student> students)
    {
        // Серіалізуємо і записуємо у файл
        string json = JsonSerializer.Serialize(students, Options);
        File.WriteAllText(_path, json);
    }
}
