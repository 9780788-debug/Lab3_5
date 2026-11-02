using Lab35.BLL;
using Lab35.DAL;
using Lab35.Models;
using Moq;

namespace Lab35.Tests;

// Тести з mock: перевіряємо, чи викликали репозиторій
public class StudentServiceMockTests
{
    [Fact]
    public void Add_ValidStudent_CallsSaveAllOnce()
    {
        // Arrange
        var mock = new Mock<IStudentRepository>();
        mock.Setup(r => r.LoadAll()).Returns(new List<Student>());
        var service = new StudentService(mock.Object);

        // Act
        service.Add(TestData.MakeStudent());

        // Assert
        mock.Verify(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()), Times.Once());
    }

    [Fact]
    public void Add_InvalidStudent_NeverCallsSaveAll()
    {
        // Arrange
        var mock = new Mock<IStudentRepository>();
        var service = new StudentService(mock.Object);

        // Act
        Assert.Throws<ArgumentException>(() => service.Add(TestData.MakeStudent(surname: "")));

        // Assert
        mock.Verify(r => r.SaveAll(It.IsAny<IEnumerable<Student>>()), Times.Never());
    }
}
