namespace Lab35.BLL.Employees;

// Базовий клас працівника зі спільними вміннями
public abstract class Employee
{
    // Ім'я працівника
    public string Name { get; }

    // Посада (задають нащадки)
    public abstract string Position { get; }

    protected Employee(string name)
    {
        // Контроль даних
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ім'я не може бути порожнім");

        Name = name;
    }

    // Готувати бургер з різних інгредієнтів
    public string CookBurger(IEnumerable<string> ingredients)
    {
        if (ingredients == null || !ingredients.Any())
            throw new ArgumentException("Потрібен хоча б один інгредієнт");

        return $"{Position} {Name} готує бургер: {string.Join(", ", ingredients)}";
    }

    // Грати в шахи
    public string PlayChess(string opponent)
    {
        if (string.IsNullOrWhiteSpace(opponent))
            throw new ArgumentException("Потрібно вказати суперника");

        return $"{Position} {Name} грає в шахи, суперник: {opponent}";
    }
}
