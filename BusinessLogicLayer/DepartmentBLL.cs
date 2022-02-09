using DataAccessLayer.DataAccessObjects;
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
    }
}
