using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

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
