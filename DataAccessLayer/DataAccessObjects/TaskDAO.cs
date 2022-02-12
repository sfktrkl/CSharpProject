using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class TaskDAO : EmployeeContext
    {
        public static void AddTask(Task task)
        {
            try
            {
                db.Tasks.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TaskState> GetTaskStates()
        {
            return db.TaskStates.ToList();
        }
    }
}
