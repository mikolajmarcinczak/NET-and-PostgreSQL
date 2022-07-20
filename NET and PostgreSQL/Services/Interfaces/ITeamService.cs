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
        Team GetTeamByName(string teamName);
        Manager GetTeamManager(string teamName);
        OperationSuccessDTO<IList<TeamWithEmpListDTO>> GetTeamWithEmployees(string teamName);
    }
}
