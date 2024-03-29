﻿using System.Collections.Generic;
using System.Linq;
using System;
using DataAccessLayer.DataTransferObjects;

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

        public static void UpdateTask(Task task)
        {
            try
            {
                Task ts = db.Tasks.First(x => x.ID == task.ID);
                ts.Title = task.Title;
                ts.Explanation = task.Explanation;
                ts.State = task.State;
                ts.EmployeeID = task.EmployeeID;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteTask(int taskID)
        {
            try
            {
                Task ts = db.Tasks.First(x => x.ID == taskID);
                db.Tasks.DeleteOnSubmit(ts);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            try
            {
                Task tsk = db.Tasks.First(x => x.ID == taskID);
                tsk.State = isAdmin ? TaskStates.Approved : TaskStates.Delivered;
                tsk.DeliveryDate = DateTime.Today;
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

        public static List<TaskDetailDTO> GetTasks()
        {
            try
            {
                return (from t in db.Tasks
                        join s in db.TaskStates on t.State equals s.ID
                        join e in db.Employees on t.EmployeeID equals e.ID
                        join d in db.Departments on e.DepartmentID equals d.ID
                        join p in db.Positions on e.PositionID equals p.ID
                        select new TaskDetailDTO
                        {
                            TaskID = t.ID,
                            Title = t.Title,
                            Explanation = t.Explanation,
                            StartDate = t.StartDate,
                            DeliveryDate = t.DeliveryDate,
                            StateName = s.Name,
                            StateID = t.State,
                            UserNo = e.UserNo,
                            Name = e.Name,
                            EmployeeID = t.EmployeeID,
                            Surname = e.Surname,
                            PositionName = p.Name,
                            DepartmentName = d.Name,
                            PositionID = e.PositionID,
                            DepartmentID = e.DepartmentID
                        }).OrderBy(x => x.StartDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
