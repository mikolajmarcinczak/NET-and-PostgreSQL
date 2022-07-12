using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public class ManagerService : IManagersService
    {
        private readonly CompanyDbContext context;
        public OperationResultDTO AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
            return new OperationResultDTO { Status = "Success" };
        }

        public OperationResultDTO DeleteManager(string name, string surname)
        {
            var manager = GetManagerByName(name, surname);

            if (manager != null)
            {
                context.Managers.Remove(manager);
                context.SaveChanges();
                return new OperationSuccessDTO<Manager> { Status = "Success" };
            }

            return new OperationErrorDTO { Code = 404, Status = $"Manager by the name {name} {surname} not found" };
        }

        public Manager GetManagerByName(string name, string surname)
        {
            return context.Managers.Where(manager => manager.Employee.Name == name && manager.Employee.Surname == surname).FirstOrDefault();
        }

        public OperationSuccessDTO<IList<Manager>> GetManagers()
        {
            List<Manager> managers = context.Managers.ToList();
            return new OperationSuccessDTO<IList<Manager>> { Status = "Success", Result = managers };
        }

        public OperationSuccessDTO<IList<Manager>> GetManagersSortedByEmploymentLength()
        {
            List<Manager> managers = context.Managers.OrderByDescending(manager => manager.DateTo - manager.DateFrom).ToList();
            return new OperationSuccessDTO<IList<Manager>> { Status = "Success", Result = managers };
        }

        public OperationSuccessDTO<IList<ManagerWithEmpListDTO>> GetManagersWithSubordinates()
        {
            List<ManagerWithEmpListDTO> resultDict = new List<ManagerWithEmpListDTO>();

            foreach (var manager in context.Managers)
            {
                EmployeeListDTO emp = new EmployeeListDTO { EmployeeList = manager.TeamNameNavigation.Emps.ToList() };
                ManagerWithEmpListDTO result = new ManagerWithEmpListDTO()
                {
                    Name = manager.Employee.Name,
                    Surname = manager.Employee.Surname,
                    Emps = emp
                };
                resultDict.Add(result);
            }

            return new OperationSuccessDTO<IList<ManagerWithEmpListDTO>> { Status = "Success", Result = resultDict };
        }
    }
}
