using Lab35.Models;

namespace Lab35.DAL;

// Контракт доступу до даних (BLL залежить тільки від нього)
public interface IStudentRepository
{
    // Прочитати всіх студентів
    List<Student> LoadAll();

    // Записати список студентів
    void SaveAll(IEnumerable<Student> students);
}
