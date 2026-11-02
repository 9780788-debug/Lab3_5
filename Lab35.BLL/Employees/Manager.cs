namespace Lab35.BLL.Employees;

// Менеджер
public class Manager : Employee
{
    public Manager(string name) : base(name) { }

    public override string Position => "Менеджер";
}
