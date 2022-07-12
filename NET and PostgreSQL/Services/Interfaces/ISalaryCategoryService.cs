using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public interface ISalaryCategoryService
    {
        OperationSuccessDTO<IList<Salarycategory>> GetCategories();
        OperationResultDTO GetEmployeesForCategory(string categoryName);
        OperationResultDTO AddSalaryCategory(Salarycategory salarycategory);
    }
}
