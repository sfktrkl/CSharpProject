using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataTransferObjects
{
    public class TaskDTO
    {
        public List<EmployeeDetailDTO> Employees { get; set; }
        public List<Department> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<TaskState> TaskStates { get; set; }
    }
}
