using Lab35.BLL;
using Lab35.DAL;
using Lab35.Models;

namespace Lab35.PL;

// Демонстрація роботи зі студентами
public static class StudentDemo
{
    public static void Run()
    {
        Console.WriteLine("=== Студенти ===");

        // Починаємо з чистого файлу
        const string path = "students.json";
        File.Delete(path);

        // Збираємо шари: файл -> сервіс
        var service = new StudentService(new FileStudentRepository(path));

        // Додаємо п'ятьох студентів
        service.Add(Make("Шевченко", 3, "ST-001", 85, "Україна", "GB-101"));
        service.Add(Make("Коваль", 3, "ST-002", 72, "Україна", "GB-102"));
        service.Add(Make("Новак", 3, "ST-003", 90, "Польща", "GB-103"));
        service.Add(Make("Мельник", 2, "ST-004", 55, "Україна", "GB-104"));
        service.Add(Make("Бондар", 3, "ST-005", 48, "Україна", "GB-105"));
        Console.WriteLine($"Усього студентів у файлі: {service.GetAll().Count}");

        // Некоректні дані відхиляє BLL
        try
        {
            service.Add(Make("Тест", 3, "ST-006", 150, "Україна", "GB-106"));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        // Операція варіанта: 3 курс, Україна
        Console.WriteLine($"Студентів 3 курсу з України: {service.CountThirdYearUkrainians()}");
        foreach (var s in service.GetThirdYearUkrainians()) Print(s);

        // Відрахування за неуспішність
        var expelled = service.ExpelFailing();
        Console.WriteLine($"Відраховано за неуспішність (бал < {StudentService.MinPassingGrade}): {expelled.Count}");
        foreach (var s in expelled) Print(s);

        // Що лишилось після відрахування
        Console.WriteLine($"Залишилось студентів: {service.GetAll().Count}");
        Console.WriteLine($"Студентів 3 курсу з України після відрахування: {service.CountThirdYearUkrainians()}");
    }

    // Швидке створення студента
    private static Student Make(string surname, int course, string ticket, double grade, string country, string gradeBook)
    {
        return new Student
        {
            Surname = surname,
            Course = course,
            StudentTicket = ticket,
            AverageGrade = grade,
            Country = country,
            GradeBookNumber = gradeBook
        };
    }

    // Вивід одного студента
    private static void Print(Student s)
    {
        Console.WriteLine($"  {s.Surname}, квиток {s.StudentTicket}, бал {s.AverageGrade}");
    }
}
