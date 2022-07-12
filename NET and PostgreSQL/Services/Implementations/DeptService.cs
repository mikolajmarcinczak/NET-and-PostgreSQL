using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services.Implementations
{
    public class DeptService : IDeptsService
    {
        private readonly CompanyDbContext context;
        public Dept GetDepartmentByName(string deptName)
        {
            return context.Depts.SingleOrDefault(dept => dept.DepartmentName == deptName);
        }

        public OperationResultDTO GetDepartmentManagers(string deptName)
        {
            Dept dept = GetDepartmentByName(deptName);
            if (dept != null)
            {
                List<Manager> managers = dept.Managers.ToList();
                if (managers.Count < 1)
                {
                    return new OperationResultDTO { Status = $"The department {deptName} has no managers assigned!" };
                }

                return new OperationSuccessDTO<IList<Manager>> { Status = "Success", Result = managers };
            }

            return new OperationErrorDTO { Code = 404, Status = $"Department with {deptName} name not found" };
        }

        public OperationSuccessDTO<IList<DepartmentWithLocationDTO>> GetDepartments()
        {
            List<DepartmentWithLocationDTO> deptsWithLocs = new List<DepartmentWithLocationDTO>();

            foreach (var dept in context.Depts)
            {
                DepartmentWithLocationDTO result = new DepartmentWithLocationDTO
                {
                    DepartmentName = dept.DepartmentName,
                    Location = dept.Location
                };
                deptsWithLocs.Add(result);
            }

            return new OperationSuccessDTO<IList<DepartmentWithLocationDTO>> { Status = "Success", Result = deptsWithLocs };
        }

        public OperationSuccessDTO<IList<DepartmentWithEmpListDTO>> GetDepartmentsWithEmployees()
        {
            List<DepartmentWithEmpListDTO> resultList = new List<DepartmentWithEmpListDTO>();

            foreach (var dept in context.Depts)
            {
                EmployeeListDTO empList = new EmployeeListDTO { EmployeeList = dept.Emps.ToList() };
                DepartmentWithEmpListDTO result = new DepartmentWithEmpListDTO()
                {
                    DepartmentName = dept.DepartmentName,
                    Emps = empList
                };

                resultList.Add(result);
            }

            return new OperationSuccessDTO<IList<DepartmentWithEmpListDTO>> { Status = "Success", Result = resultList };
        }

        public OperationResultDTO GetDepartmentTeamCount(string deptName)
        {
            Dept dept = GetDepartmentByName(deptName);
        }
    }
}
