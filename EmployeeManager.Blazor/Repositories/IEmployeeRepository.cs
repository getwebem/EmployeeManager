namespace EmployeeManager.Blazor.Repositories
{
    public class IEmployeeRepository
    {
        List<Employee> SelectAll();
        Employee SelectByID(int id);
        void Insert(Employee emp);
        void Update(Employee emp);
        void Delete(int id);
        List<string> SelectCountries();
    }
}
