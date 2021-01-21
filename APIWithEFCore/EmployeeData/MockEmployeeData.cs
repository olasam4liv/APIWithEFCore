using APIWithEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWithEFCore.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {

        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Samuel Olatunji"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Adebimpe Olatunji"
            },
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
             employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
             employees.Remove(employee); 
        }

        public Employee EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid Id)
        {
            return employees.SingleOrDefault(x => x.Id == Id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
