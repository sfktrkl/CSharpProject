using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataTransferObjects
{
    public class PositionDTO : Position
    {
        public string DepartmentName { get; set; }
    }
}
