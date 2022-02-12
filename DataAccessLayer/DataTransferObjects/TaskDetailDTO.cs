using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataTransferObjects
{
    public class TaskDetailDTO
    {
        public string Title { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string StateName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public int StateID { get; set; }
        public int TaskID { get; set; }
        public int EmployeeID { get; set; }
        public string Explanation { get; set; }
    }
}
