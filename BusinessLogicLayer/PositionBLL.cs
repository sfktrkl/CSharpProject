using DataAccessLayer.DataTransferObjects;
using DataAccessLayer.DataAccessObjects;
using System.Collections.Generic;
using DataAccessLayer;
using System;

namespace BusinessLogicLayer
{
    public class PositionBLL
    {
        public static void AddPosition(Position position)
        {
            PositionDAO.AddPosition(position);
        }

        public static void UpdatePosition(Position position)
        {
            PositionDAO.UpdatePosition(position);
            EmployeeDAO.UpdateEmployee(position);
        }

        public static void DeletePosition(int positionID)
        {
            PositionDAO.DeletePosition(positionID);
        }

        public static List<PositionDTO> GetPositions()
        {
            return PositionDAO.GetPositions();
        }
    }
}
