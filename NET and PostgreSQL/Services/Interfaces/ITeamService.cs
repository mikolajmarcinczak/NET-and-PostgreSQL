using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface ITeamService
    {
        OperationSuccessDTO<IList<TeamWithManagerDTO>> GetTeams();
        OperationResultDTO GetTeamByName(string teamName);
        OperationResultDTO GetTeamWithEmployees(string teamName);
        OperationResultDTO GetTeamManager(string teamName);
    }
}
