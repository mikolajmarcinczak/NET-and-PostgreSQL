using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public class TeamService : ITeamService
    {
        private readonly CompanyDbContext context;
        public Team GetTeamByName(string teamName)
        {
            return context.Teams.SingleOrDefault(team => team.TeamName == teamName);
        }

        public Manager GetTeamManager(string teamName)
        {
            return context.Managers.Where(m => m.DateTo > DateTime.Now).SingleOrDefault(m => m.TeamName == teamName);
        }

        public OperationSuccessDTO<IList<TeamWithManagerDTO>> GetTeams()
        {
            var teamsWithManagers = new List<TeamWithManagerDTO>();

            foreach (var team in context.Teams)
            {
                TeamWithManagerDTO result = new TeamWithManagerDTO
                {
                    TeamName = team.TeamName,
                    DepartmentName = team.DepartmentName,
                    Manager = GetTeamManager(team.TeamName)
                };
                teamsWithManagers.Add(result);
            }

            return new OperationSuccessDTO<IList<TeamWithManagerDTO>> { Status = "Success", Result = teamsWithManagers };
        }

        public OperationSuccessDTO<IList<TeamWithEmpListDTO>> GetTeamWithEmployees(string teamName)
        {
            List<TeamWithEmpListDTO> resultList = new List<TeamWithEmpListDTO>();

            foreach (var team in context.Teams)
            {
                EmployeeListDTO empList = new EmployeeListDTO { EmployeeList = team.Emps.ToList() };
                TeamWithEmpListDTO result = new TeamWithEmpListDTO()
                {
                    TeamName = team.TeamName,
                    EmployeeList = empList
                };
                resultList.Add(result);
            }

            return new OperationSuccessDTO<IList<TeamWithEmpListDTO>> { Status = "Success", Result = resultList };
        }
    }
}
