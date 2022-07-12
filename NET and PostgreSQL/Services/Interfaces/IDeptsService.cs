using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface IDeptsService
    {
        Dept GetDepartmentByName(string deptName);
        OperationSuccessDTO<IList<DepartmentWithLocationDTO>> GetDepartments();
        OperationResultDTO GetDepartmentTeamCount(string deptName);
        OperationResultDTO GetDepartmentManagers(string deptName);
        OperationSuccessDTO<IList<DepartmentWithEmpListDTO>> GetDepartmentsWithEmployees();
    }
}
