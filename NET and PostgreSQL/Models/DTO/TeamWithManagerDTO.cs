using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class TeamWithManagerDTO
    {
        public string TeamName { get; set; }
        public string DepartmentName { get; set; }
        public Manager Manager { get; set; }
    }
}
