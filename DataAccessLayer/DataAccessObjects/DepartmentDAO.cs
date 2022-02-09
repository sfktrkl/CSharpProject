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
    }
}
