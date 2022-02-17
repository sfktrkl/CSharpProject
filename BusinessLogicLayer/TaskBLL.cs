using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class TaskBLL
    {
        public static void AddTask(Task task)
        {
            TaskDAO.AddTask(task);
        }

        public static void UpdateTask(Task task)
        {
            TaskDAO.UpdateTask(task);
        }
        public static void DeleteTask(int taskID)
        {
            TaskDAO.DeleteTask(taskID);
        }

        public static TaskDTO GetAll()
        {
            TaskDTO dto = new TaskDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            dto.TaskStates = TaskDAO.GetTaskStates();
            dto.Tasks = TaskDAO.GetTasks();
            return dto;
        }
    }
}
