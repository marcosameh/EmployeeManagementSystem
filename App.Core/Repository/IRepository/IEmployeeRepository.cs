using App.Data.Entities;

namespace App.Core.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task SaveAsync();
    }
}
