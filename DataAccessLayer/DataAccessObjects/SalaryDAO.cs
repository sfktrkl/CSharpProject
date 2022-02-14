using DataAccessLayer.DataTransferObjects;
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

        public static void UpdateSalary(Salary salary)
        {
            try
            {
                Salary sl = db.Salaries.First(x => x.ID == salary.ID);
                sl.Amount = salary.Amount;
                sl.Year = salary.Year;
                sl.MonthID = salary.MonthID;
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

        public static List<SalaryDetailDTO> GetSalaries()
        {
            try
            {
                return (from s in db.Salaries
                        join e in db.Employees on s.EmployeeID equals e.ID
                        join m in db.Months on s.MonthID equals m.ID
                        select new SalaryDetailDTO
                        {
                            UserNo = e.UserNo,
                            Name = e.Name,
                            Surname = e.Surname,
                            EmployeeID = s.EmployeeID,
                            SalaryAmount = s.Amount,
                            SalaryYear = s.Year,
                            MonthName = m.Name,
                            MonthID = s.MonthID,
                            SalaryID = s.ID,
                            DepartmentID = e.DepartmentID,
                            PositionID = e.PositionID
                        }).OrderBy(x => x.SalaryYear).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
