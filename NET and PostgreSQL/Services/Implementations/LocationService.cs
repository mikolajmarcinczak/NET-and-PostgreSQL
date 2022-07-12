using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public class LocationService : ILocationsService
    {
        private readonly CompanyDbContext context;

        public OperationResultDTO GetDepartmentsForCity(string cityName)
        {            
            List<Dept> depts = context.Depts.Where(dept => dept.Location.City == cityName).ToList();
            if (depts.Count > 0)
            {
                return new OperationSuccessDTO<IList<Dept>> { Status = "Success", Result = depts };
            }

            return new OperationErrorDTO { Code = 404, Status = $"City with name {cityName} not found." };
        }

        public OperationSuccessDTO<IList<Location>> GetLocations()
        {
            List<Location> locations = context.Locations.ToList();
            return new OperationSuccessDTO<IList<Location>> { Status = "Success", Result = locations };
        }

        public OperationResultDTO NumberOfTeamsByLocation()
        {
            List<LocationWithTeamsDTO> locations = new List<LocationWithTeamsDTO>();
            foreach (var location in context.Locations)
            {
                int tcount = 0;
                foreach (var department in location.Depts)
                {
                    tcount += department.Teams.Count;
                }

                LocationWithTeamsDTO element = new LocationWithTeamsDTO
                {
                    Location = location,
                    TeamCount = tcount
                };

                locations.Append(element);
            }

            return new OperationSuccessDTO<IList<LocationWithTeamsDTO>> { Status = "Success", Result = locations };
        }
    }
}
