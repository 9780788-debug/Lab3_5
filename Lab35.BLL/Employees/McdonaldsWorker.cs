namespace Lab35.BLL.Employees;

// Працівник McDonald's
public class McdonaldsWorker : Employee
{
    public McdonaldsWorker(string name) : base(name) { }

    public override string Position => "Працівник McDonald's";
}
