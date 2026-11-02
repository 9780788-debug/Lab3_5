using Lab35.BLL.Employees;

namespace Lab35.PL;

// Демонстрація працівників
public static class EmployeeDemo
{
    public static void Run()
    {
        Console.WriteLine("=== Працівники ===");

        var worker = new McdonaldsWorker("Іван");
        var manager = new Manager("Олена");

        // Готування бургерів
        Console.WriteLine(worker.CookBurger(new[] { "булка", "котлета", "сир", "салат" }));
        Console.WriteLine(manager.CookBurger(new[] { "булка", "котлета", "помідор" }));

        // Гра в шахи
        Console.WriteLine(worker.PlayChess("Олена"));
        Console.WriteLine(manager.PlayChess("Іван"));

        // Некоректні дані відхиляє BLL
        try
        {
            worker.CookBurger(new List<string>());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
