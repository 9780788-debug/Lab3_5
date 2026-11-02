using Lab35.Models;

namespace Lab35.BLL;

// Контроль даних студента (рівень бізнес-логіки)
public static class StudentValidator
{
    public static void Validate(Student student)
    {
        // Студент не може бути null
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        // Текстові поля не порожні
        if (string.IsNullOrWhiteSpace(student.Surname))
            throw new ArgumentException("Прізвище не може бути порожнім");

        // Курс від 1 до 6
        if (student.Course < 1 || student.Course > 6)
            throw new ArgumentException("Курс має бути від 1 до 6");

        if (string.IsNullOrWhiteSpace(student.StudentTicket))
            throw new ArgumentException("Студентський квиток не може бути порожнім");

        // Бал від 0 до 100
        if (student.AverageGrade < 0 || student.AverageGrade > 100)
            throw new ArgumentException("Середній бал має бути від 0 до 100");

        if (string.IsNullOrWhiteSpace(student.Country))
            throw new ArgumentException("Країна не може бути порожньою");

        if (string.IsNullOrWhiteSpace(student.GradeBookNumber))
            throw new ArgumentException("Номер залікової книжки не може бути порожнім");
    }
}
