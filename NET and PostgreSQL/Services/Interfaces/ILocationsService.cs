using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface ILocationsService
    {
        OperationSuccessDTO<IList<Location>> GetLocations();
        OperationResultDTO GetDepartmentsForCity(string cityName);
        OperationResultDTO NumberOfTeamsByLocation();
    }
}
