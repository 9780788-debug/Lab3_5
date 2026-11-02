using Lab35.BLL;
using Lab35.Tests.Fakes;

namespace Lab35.Tests;

// Тести сервісу студентів (через заглушку-репозиторій)
public class StudentServiceTests
{
    [Fact]
    public void Add_ValidStudent_SavesToRepository()
    {
        // Arrange
        var stub = new StubStudentRepository();
        var service = new StudentService(stub);

        // Act
        service.Add(TestData.MakeStudent());

        // Assert
        Assert.Single(stub.Data);
    }

    [Fact]
    public void Add_InvalidStudent_ThrowsAndDoesNotSave()
    {
        // Arrange
        var stub = new StubStudentRepository();
        var service = new StudentService(stub);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => service.Add(TestData.MakeStudent(grade: 150)));
        Assert.Empty(stub.Data);
    }

    [Fact]
    public void GetAll_ReturnsAllStudents()
    {
        // Arrange
        var stub = new StubStudentRepository(
            TestData.MakeStudent(ticket: "ST-001"),
            TestData.MakeStudent(ticket: "ST-002"));
        var service = new StudentService(stub);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void CountThirdYearUkrainians_MixedStudents_CountsOnlyMatching()
    {
        // Arrange
        var stub = new StubStudentRepository(
            TestData.MakeStudent(surname: "А", course: 3, country: "Україна"),
            TestData.MakeStudent(surname: "Б", course: 3, country: "Україна"),
            TestData.MakeStudent(surname: "В", course: 3, country: "Польща"),
            TestData.MakeStudent(surname: "Г", course: 2, country: "Україна"));
        var service = new StudentService(stub);

        // Act
        int count = service.CountThirdYearUkrainians();

        // Assert
        Assert.Equal(2, count);
    }

    [Fact]
    public void CountThirdYearUkrainians_EmptyRepository_ReturnsZero()
    {
        // Arrange
        var service = new StudentService(new StubStudentRepository());

        // Act
        int count = service.CountThirdYearUkrainians();

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public void GetThirdYearUkrainians_ReturnsMatchingStudents()
    {
        // Arrange
        var stub = new StubStudentRepository(
            TestData.MakeStudent(surname: "А", course: 3, country: "Україна"),
            TestData.MakeStudent(surname: "Б", course: 1, country: "Україна"));
        var service = new StudentService(stub);

        // Act
        var result = service.GetThirdYearUkrainians();

        // Assert
        Assert.Equal("А", Assert.Single(result).Surname);
    }

    [Fact]
    public void ExpelFailing_StudentsBelowMinimum_RemovesThemAndKeepsRest()
    {
        // Arrange
        var stub = new StubStudentRepository(
            TestData.MakeStudent(surname: "Слабкий", grade: 45),
            TestData.MakeStudent(surname: "Межа", grade: 60),
            TestData.MakeStudent(surname: "Сильний", grade: 80));
        var service = new StudentService(stub);

        // Act
        var expelled = service.ExpelFailing();

        // Assert
        Assert.Equal("Слабкий", Assert.Single(expelled).Surname);
        Assert.Equal(2, stub.Data.Count);
    }

    [Fact]
    public void ExpelFailing_NobodyFails_ReturnsEmptyAndKeepsAll()
    {
        // Arrange
        var stub = new StubStudentRepository(TestData.MakeStudent(grade: 90));
        var service = new StudentService(stub);

        // Act
        var expelled = service.ExpelFailing();

        // Assert
        Assert.Empty(expelled);
        Assert.Single(stub.Data);
    }
}
