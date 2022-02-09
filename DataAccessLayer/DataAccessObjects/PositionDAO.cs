using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataAccessObjects
{
    public class PositionDAO : EmployeeContext
    {
        public static void AddPosition(Position position)
        {
            try
            {
                db.Positions.InsertOnSubmit(position);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
