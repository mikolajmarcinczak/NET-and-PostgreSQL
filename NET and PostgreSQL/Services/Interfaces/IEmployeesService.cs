using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface IEmployeesService
    {
        Emp GetEmployeeByName(string name, string surname);
        OperationSuccessDTO<EmployeeListDTO> GetEmployees();
        OperationResultDTO GetEmployeeWithProjects(string name, string surname);
        OperationResultDTO AddEmployee(Emp employee);
        OperationResultDTO DeleteEmployee(string name, string surname);
    }
}
