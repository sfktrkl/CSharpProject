using DataAccessLayer.DataTransferObjects;
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

        public static List<PositionDTO> GetPositions()
        {
            try
            {
                return (from p in db.Positions
                        join d in db.Departments on p.DepartmentID equals d.ID
                        select new PositionDTO
                        {
                            ID = p.ID,
                            Name = p.Name,
                            DepartmentName = d.Name,
                            DepartmentID = d.ID
                        }).OrderBy(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
