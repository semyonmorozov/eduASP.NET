using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentGroup.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "First name required")]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student card number required")]
        [Range(10000000, 99999999, ErrorMessage = "Student card number must be eight digits")]
        public int StudentCardNumber { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public Dictionary<HomeWorkModel,int> DoneHomeWorks = new Dictionary<HomeWorkModel, int>();
        
    }
    
}
