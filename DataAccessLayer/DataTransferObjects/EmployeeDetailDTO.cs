﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessLayer.DataTransferObjects
{
    public class EmployeeDetailDTO
    {
        public int EmployeeID { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public int Salary { get; set; }
        public bool? IsAdmin { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Adress { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
