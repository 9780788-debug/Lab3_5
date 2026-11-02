using Lab35.BLL.Employees;

namespace Lab35.Tests;

// Тести працівників (специфічні операції, яких немає у Student)
public class EmployeeTests
{
    [Fact]
    public void CookBurger_WithIngredients_ReturnsDescription()
    {
        // Arrange
        var worker = new McdonaldsWorker("Іван");

        // Act
        string result = worker.CookBurger(new[] { "булка", "котлета", "сир" });

        // Assert
        Assert.Equal("Працівник McDonald's Іван готує бургер: булка, котлета, сир", result);
    }

    [Fact]
    public void CookBurger_ManagerWithIngredients_ReturnsDescription()
    {
        // Arrange
        var manager = new Manager("Олена");

        // Act
        string result = manager.CookBurger(new[] { "булка", "помідор" });

        // Assert
        Assert.Equal("Менеджер Олена готує бургер: булка, помідор", result);
    }

    [Fact]
    public void CookBurger_EmptyIngredients_ThrowsArgumentException()
    {
        // Arrange
        var worker = new McdonaldsWorker("Іван");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => worker.CookBurger(new List<string>()));
    }

    [Fact]
    public void CookBurger_NullIngredients_ThrowsArgumentException()
    {
        // Arrange
        var worker = new McdonaldsWorker("Іван");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => worker.CookBurger(null!));
    }

    [Fact]
    public void PlayChess_ValidOpponent_ReturnsDescription()
    {
        // Arrange
        var manager = new Manager("Олена");

        // Act
        string result = manager.PlayChess("Іван");

        // Assert
        Assert.Equal("Менеджер Олена грає в шахи, суперник: Іван", result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void PlayChess_EmptyOpponent_ThrowsArgumentException(string opponent)
    {
        // Arrange
        var worker = new McdonaldsWorker("Іван");

        // Act + Assert
        Assert.Throws<ArgumentException>(() => worker.PlayChess(opponent));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_EmptyName_ThrowsArgumentException(string name)
    {
        // Act + Assert
        Assert.Throws<ArgumentException>(() => new McdonaldsWorker(name));
    }
}
