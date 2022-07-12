using NET_and_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Services
{
    public class SalaryCategoryService : ISalaryCategoryService
    {
        private readonly CompanyDbContext context;
        public OperationResultDTO AddSalaryCategory(Salarycategory salarycategory)
        {
            context.Salarycategories.Add(salarycategory);
            context.SaveChanges();
            return new OperationResultDTO { Status = "Success" };
        }

        public OperationSuccessDTO<IList<Salarycategory>> GetCategories()
        {
            List<Salarycategory> salarycategories = context.Salarycategories.ToList();
            return new OperationSuccessDTO<IList<Salarycategory>> { Status = "Success", Result = salarycategories };
        }

        public OperationResultDTO GetEmployeesForCategory(string categoryName)
        {
            Salarycategory salarycategory = context.Salarycategories.SingleOrDefault(category => category.CategoryName == categoryName);
            if (salarycategory == null)
            {
                return new OperationErrorDTO { Code = 404, Status = $"Category with name {categoryName} not found" };
            }

            List<Emp> empList = salarycategory.Emps.ToList();

            if (empList.Count > 0) 
            {
                return new OperationSuccessDTO<EmployeeListDTO> { Status = "Success", Result = new EmployeeListDTO { EmployeeList = empList } };
            }

            return new OperationResultDTO { Status = $"No employees have the {salarycategory.CategoryName} salary category" };
        }
    }
}
