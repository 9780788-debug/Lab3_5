using Lab35.DAL;

namespace Lab35.Tests;

// Тести файлового репозиторію (використовують тимчасовий файл)
public class FileStudentRepositoryTests : IDisposable
{
    // Унікальний тимчасовий файл для кожного тесту
    private readonly string _path = Path.Combine(Path.GetTempPath(), $"students_{Guid.NewGuid()}.json");

    // Прибираємо файл після тесту
    public void Dispose()
    {
        File.Delete(_path);
    }

    [Fact]
    public void LoadAll_FileDoesNotExist_ReturnsEmptyList()
    {
        // Arrange
        var repository = new FileStudentRepository(_path);

        // Act
        var result = repository.LoadAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SaveAll_ThenLoadAll_ReturnsSameData()
    {
        // Arrange
        var repository = new FileStudentRepository(_path);
        var students = new[] { TestData.MakeStudent(surname: "Шевченко", grade: 85) };

        // Act
        repository.SaveAll(students);
        var loaded = repository.LoadAll();

        // Assert
        var student = Assert.Single(loaded);
        Assert.Equal("Шевченко", student.Surname);
        Assert.Equal(85, student.AverageGrade);
    }
}
