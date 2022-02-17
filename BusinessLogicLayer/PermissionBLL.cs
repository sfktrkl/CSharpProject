using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class PermissionBLL
    {
        public static void AddPermission(Permission permission)
        {
            PermissionDAO.AddPermission(permission);
        }

        public static void UpdatePermission(Permission permission)
        {
            PermissionDAO.UpdatePermission(permission);
        }


        public static void UpdatePermission(int permissionID, int permissionState)
        {
            PermissionDAO.UpdatePermission(permissionID, permissionState);
        }

        public static void DeletePermission(int permissionID)
        {
            PermissionDAO.DeletePermission(permissionID);
        }

        public static PermissionDTO GetAll()
        {
            PermissionDTO dto = new PermissionDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.States = PermissionDAO.GetStates();
            dto.Permissions = PermissionDAO.GetPermissions();
            return dto;
        }
    }
}
