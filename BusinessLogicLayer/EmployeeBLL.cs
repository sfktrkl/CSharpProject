using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class EmployeeBLL
    {
        public static void AddEmployee(Employee employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static void UpdateEmployee(Employee employee)
        {
            EmployeeDAO.UpdateEmployee(employee);
        }

        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            return dto;
        }

        public static bool isUnique(int userNo)
        {
            List<Employee> list = EmployeeDAO.GetUsers(userNo);
            if (list.Count > 0)
                return false;
            return true;
        }

        public static List<EmployeeDetailDTO> GetEmployees(int userNo, string password)
        {
            return EmployeeDAO.GetEmployees(userNo, password);
        }
    }
}
