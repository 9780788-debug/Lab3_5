using Lab35.BLL;

namespace Lab35.Tests;

// Тести контролю даних студента
public class StudentValidatorTests
{
    [Fact]
    public void Validate_NullStudent_ThrowsArgumentNullException()
    {
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => StudentValidator.Validate(null!));
    }

    [Theory]
    [InlineData(1, 0.0)]
    [InlineData(6, 100.0)]
    public void Validate_BoundaryValues_DoesNotThrow(int course, double grade)
    {
        // Arrange
        var student = TestData.MakeStudent(course: course, grade: grade);

        // Act
        var exception = Record.Exception(() => StudentValidator.Validate(student));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Validate_EmptySurname_ThrowsArgumentException(string surname)
    {
        // Arrange
        var student = TestData.MakeStudent(surname: surname);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    public void Validate_CourseOutOfRange_ThrowsArgumentException(int course)
    {
        // Arrange
        var student = TestData.MakeStudent(course: course);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }

    [Fact]
    public void Validate_EmptyTicket_ThrowsArgumentException()
    {
        // Arrange
        var student = TestData.MakeStudent(ticket: "");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }

    [Theory]
    [InlineData(-1.0)]
    [InlineData(101.0)]
    public void Validate_GradeOutOfRange_ThrowsArgumentException(double grade)
    {
        // Arrange
        var student = TestData.MakeStudent(grade: grade);

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }

    [Fact]
    public void Validate_EmptyCountry_ThrowsArgumentException()
    {
        // Arrange
        var student = TestData.MakeStudent(country: "");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }

    [Fact]
    public void Validate_EmptyGradeBook_ThrowsArgumentException()
    {
        // Arrange
        var student = TestData.MakeStudent(gradeBook: "");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => StudentValidator.Validate(student));
    }
}
