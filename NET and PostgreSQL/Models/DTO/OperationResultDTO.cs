using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class OperationResultDTO
    {
        public string Status { get; set; }
    }
    public class OperationErrorDTO : OperationResultDTO
    {
        public int Code { get; set; }
    }
    public class OperationSuccessDTO<T> : OperationResultDTO where T : class
    {
        public T Result { get; set; }
    }
}
