using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class EmployeeWithProjectsDTO
    {
        public Emp Employee { get; set; }
        public ProjectListDTO ProjectListDTO { get; set; }
    }
}
