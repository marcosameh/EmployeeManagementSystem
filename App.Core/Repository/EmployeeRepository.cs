using App.Core.Repository.IRepository;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementSystemContext _db;

        public EmployeeRepository(EmployeeManagementSystemContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Employee employee)
        {
            await _db.AddAsync(employee);
        }

        public async Task DeleteAsync(Employee employee)
        {
            _db.Employees.Remove(employee);
        }

        public async Task<ICollection<Employee>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _db.Employees.Update(employee);
        }
    }
}
