using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateEmployee(int employeeID, int amount)
        {
            try
            {
                Employee employee = db.Employees.First(x => x.ID == employeeID);
                employee.Salary = amount;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetUsers(int userNo)
        {
            return db.Employees.Where(x => x.UserNo == userNo).ToList();
        }

        public static List<EmployeeDetailDTO> GetEmployees()
        {
            try
            {
                return (from e in db.Employees
                        join d in db.Departments on e.DepartmentID equals d.ID
                        join p in db.Positions on e.PositionID equals p.ID
                        select new EmployeeDetailDTO
                        {
                            UserNo = e.UserNo,
                            Name = e.Name,
                            Surname = e.Surname,
                            EmployeeID = e.ID,
                            Password = e.Password,
                            DepartmentName = d.Name,
                            PositionName = p.Name,
                            DepartmentID = e.DepartmentID,
                            PositionID = e.PositionID,
                            IsAdmin = e.isAdmin,
                            Salary = e.Salary,
                            ImagePath = e.ImagePath,
                            Birthday = e.Birthday,
                            Adress = e.Adress
                        }).OrderBy(x => x.UserNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<EmployeeDetailDTO> GetEmployees(int userNo, string password)
        {
            try
            {
                return (from e in db.Employees
                        where e.UserNo == userNo
                        where e.Password == password
                        select new EmployeeDetailDTO
                        {
                            UserNo = e.UserNo,
                            EmployeeID = e.ID,
                            IsAdmin = e.isAdmin,
                        }).OrderBy(x => x.UserNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
