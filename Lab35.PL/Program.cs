namespace Lab35.PL;

public class Program
{
    public static void Main()
    {
        // Щоб українські літери виводились правильно
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        StudentDemo.Run();
        Console.WriteLine();
        EmployeeDemo.Run();
    }
}
