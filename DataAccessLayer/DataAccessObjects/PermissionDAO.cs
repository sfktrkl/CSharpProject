﻿using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class PermissionDAO : EmployeeContext
    {
        public static void AddPermission(Permission permission)
        {
            try
            {
                db.Permissions.InsertOnSubmit(permission);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(Permission permission)
        {
            try
            {
                Permission pr = db.Permissions.First(x => x.ID == permission.ID);
                pr.StartDate = permission.StartDate;
                pr.EndDate = permission.EndDate;
                pr.Explanation = permission.Explanation;
                pr.Day = permission.Day;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePermission(int permissionID, int permissionState)
        {
            try
            {
                Permission pr = db.Permissions.First(x => x.ID == permissionID);
                pr.State = permissionState;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletePermission(int permissionID)
        {
            try
            {
                Permission pr = db.Permissions.First(x => x.ID == permissionID);
                db.Permissions.DeleteOnSubmit(pr);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<PermissionState> GetStates()
        {
            return db.PermissionStates.ToList();
        }

        public static List<PermissionDetailDTO> GetPermissions()
        {
            try
            {
                return (from p in db.Permissions
                        join s in db.PermissionStates on p.State equals s.ID
                        join e in db.Employees on p.EmployeeID equals e.ID
                        select new PermissionDetailDTO
                        {
                            UserNo = e.UserNo,
                            Name = e.Name,
                            Surname = e.Surname,
                            StateName = s.Name,
                            State = p.State,
                            StartDate = p.StartDate,
                            EndDate = p.EndDate,
                            EmployeeID = p.EmployeeID,
                            PermissionID = p.ID,
                            Explanation = p.Explanation,
                            PermissionDayAmount = p.Day,
                            DepartmentID = e.DepartmentID,
                            PositionID = e.PositionID
                        }).OrderBy(x => x.StartDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
