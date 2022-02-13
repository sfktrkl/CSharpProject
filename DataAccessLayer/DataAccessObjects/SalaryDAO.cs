using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class SalaryDAO : EmployeeContext
    {
        public static void AddTask(Salary salary)
        {
            try
            {
                db.Salaries.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Month> GetMonths()
        {
            return db.Months.ToList();
        }
    }
}
