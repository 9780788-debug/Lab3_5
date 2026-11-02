using Lab35.Models;

namespace Lab35.Tests;

// Допоміжний клас: швидке створення студентів для тестів
public static class TestData
{
    public static Student MakeStudent(
        string surname = "Шевченко",
        int course = 3,
        string ticket = "ST-001",
        double grade = 85,
        string country = "Україна",
        string gradeBook = "GB-101")
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
}
