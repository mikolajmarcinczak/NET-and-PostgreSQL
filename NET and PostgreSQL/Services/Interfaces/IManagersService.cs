using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface IManagersService
    {
        OperationSuccessDTO<IList<Manager>> GetManagers();
        OperationSuccessDTO<IList<Manager>> GetManagersSortedByEmploymentLength();
        OperationSuccessDTO<IList<ManagerWithEmpListDTO>> GetManagersWithSubordinates();
        Manager GetManagerByName(string name, string surname);
        OperationResultDTO AddManager(Manager manager);
        OperationResultDTO DeleteManager(string name, string surname);
    }
}
