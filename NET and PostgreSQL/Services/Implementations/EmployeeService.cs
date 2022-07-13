using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly CompanyDbContext context;

        public OperationResultDTO AddEmployee(Emp employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return new OperationResultDTO { Status = "Success" };
        }

        public OperationResultDTO DeleteEmployee(string name, string surname)
        {
            Emp emp = GetEmployeeByName(name, surname);
            if (emp == null)
            {
                return new OperationErrorDTO { Code = 404, Status = $"Employee with name {name} {surname} not found" };
            }
            context.Remove(emp);
            context.SaveChanges();

            return new OperationResultDTO { Status = "Success" };
        }

        public Emp GetEmployeeByName(string name, string surname)
        {
            return context.Emps.FirstOrDefault(emp => emp.Name == name && emp.Surname == surname);
        }

        public OperationSuccessDTO<EmployeeListDTO> GetEmployees()
        {
            EmployeeListDTO emps = new EmployeeListDTO
            {
                EmployeeList = context.Emps.ToList()
            };

            return new OperationSuccessDTO<EmployeeListDTO> { Status = "Success", Result = emps };
        }

        public OperationResultDTO GetEmployeeWithProjects(string name, string surname)
        {
            Emp employee = GetEmployeeByName(name, surname);

            if (employee == null)
            {
                return new OperationErrorDTO { Code = 404, Status = $"Employee with name {name} {surname} not found" };
            }

            List<Proj> projects = new List<Proj>();
            foreach (var project in employee.Assignprojects)
            {
                projects.Append(project.ProjectNameNavigation);
            }

            if (projects.Count < 1)
            {
                return new OperationResultDTO { Status = $"Employee with name {name} {surname} does not have any projects assigned" };
            }

            EmployeeWithProjectsDTO employeeWithProjects = new EmployeeWithProjectsDTO
            {
                Employee = employee,
                ProjectListDTO = new ProjectListDTO { ProjectList = projects }
            };

            return new OperationSuccessDTO<EmployeeWithProjectsDTO> { Status = "Success", Result = employeeWithProjects };
        }
    }
}
