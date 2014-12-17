using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MvcAppVs2013.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get; set;}
        public string Name { get; set; }
        public string Departmentt { get; set; }
        public long Phone { get; set; }
    }
}