namespace Lab35.Models;

// Модель студента (тільки дані, без логіки)
public class Student
{
    // Прізвище
    public string Surname { get; set; } = "";

    // Курс (1-6)
    public int Course { get; set; }

    // Номер студентського квитка
    public string StudentTicket { get; set; } = "";

    // Середній бал (0-100)
    public double AverageGrade { get; set; }

    // Країна проживання
    public string Country { get; set; } = "";

    // Номер залікової книжки
    public string GradeBookNumber { get; set; } = "";
}
