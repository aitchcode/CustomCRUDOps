using System;
using System.ComponentModel.DataAnnotations;

namespace CustomCRUDOps.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DOB { get; set;}
        
        public string EmailAddress { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string HomeAddress { get; set; }
    }
}
