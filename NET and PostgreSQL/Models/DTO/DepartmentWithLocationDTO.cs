using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class DepartmentWithLocationDTO
    {
        public string DepartmentName { get; set; }
        public Location Location { get; set; }
    }
}
