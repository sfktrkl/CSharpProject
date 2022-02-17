using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class SalaryBLL
    {
        public static void AddSalary(Salary salary)
        {
            SalaryDAO.AddTask(salary);
            EmployeeDAO.UpdateEmployee(salary.EmployeeID, salary.Amount);
        }

        public static void UpdateSalary(Salary salary)
        {
            SalaryDAO.UpdateSalary(salary);
            EmployeeDAO.UpdateEmployee(salary.EmployeeID, salary.Amount);
        }

        public static void DeleteSalary(int salaryID)
        {
            SalaryDAO.DeleteSalary(salaryID);
        }

        public static SalaryDTO GetAll()
        {
            SalaryDTO dto = new SalaryDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.Months = SalaryDAO.GetMonths();
            dto.Salaries = SalaryDAO.GetSalaries();
            return dto;
        }
    }
}
