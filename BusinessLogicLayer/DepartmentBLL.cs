using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class DepartmentBLL
    {
        public static void AddDepartment(Department department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static void UpdateDepartment(Department department)
        {
            DepartmentDAO.UpdateDepartment(department);
        }

        public static void DeleteDepartment(int departmentID)
        {
            DepartmentDAO.DeleteDepartment(departmentID);
        }

        public static List<Department> GetDepartments()
        {
            return DepartmentDAO.GetDepartments();
        }
    }
}
