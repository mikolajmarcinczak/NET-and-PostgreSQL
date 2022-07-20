using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class TeamWithEmpListDTO
    {
        public string TeamName { get; set; }
        public EmployeeListDTO EmployeeList { get; set; }
    }
}
