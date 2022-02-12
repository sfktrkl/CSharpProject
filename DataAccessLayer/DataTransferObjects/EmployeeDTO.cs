using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataTransferObjects
{
    public class EmployeeDTO
    {
        public List<Department> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
    }
}
