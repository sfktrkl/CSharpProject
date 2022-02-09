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
    }
}
