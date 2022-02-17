using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class DepartmentDAO : EmployeeContext
    {
        public static void AddDepartment(Department department)
        {
            try
            {
                db.Departments.InsertOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateDepartment(Department department)
        {
            try
            {
                Department dpt = db.Departments.First(x => x.ID == department.ID);
                dpt.Name = department.Name;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteDepartment(int departmentID)
        {
            try
            {
                Department department = db.Departments.First(x => x.ID == departmentID);
                db.Departments.DeleteOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }
    }
}
