using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class ManagerWithEmpListDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeListDTO Emps { get; set; }
    }
}
