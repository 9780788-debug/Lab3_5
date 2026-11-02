using Lab35.DAL;
using Lab35.Models;

namespace Lab35.BLL;

// Бізнес-логіка роботи зі студентами
public class StudentService
{
    // Мінімальний бал, нижче якого відраховують
    public const double MinPassingGrade = 60;

    // Країна, яку рахуємо "своєю"
    public const string HomeCountry = "Україна";

    // Залежність від інтерфейсу (DI через конструктор)
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    // Додати студента (спочатку перевірка даних)
    public void Add(Student student)
    {
        StudentValidator.Validate(student);

        var all = _repository.LoadAll();
        all.Add(student);
        _repository.SaveAll(all);
    }

    // Усі студенти
    public List<Student> GetAll()
    {
        return _repository.LoadAll();
    }

    // Студенти 3 курсу, які проживають в Україні
    public List<Student> GetThirdYearUkrainians()
    {
        return _repository.LoadAll()
            .Where(s => s.Course == 3 && s.Country == HomeCountry)
            .ToList();
    }

    // Їх кількість
    public int CountThirdYearUkrainians()
    {
        return GetThirdYearUkrainians().Count;
    }

    // Відрахування за неуспішність: повертає відрахованих
    public List<Student> ExpelFailing()
    {
        var all = _repository.LoadAll();

        // Ті, кого відраховують, і ті, хто залишається
        var expelled = all.Where(s => s.AverageGrade < MinPassingGrade).ToList();
        var remaining = all.Where(s => s.AverageGrade >= MinPassingGrade).ToList();

        _repository.SaveAll(remaining);
        return expelled;
    }
}
