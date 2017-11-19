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

        [Required(ErrorMessage = "Age required")]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Student card number required")]
        [Range(10000000, 99999999)]
        public int StudentCardNumber { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public List<string> DoneHomeWorks = new List<string>();

        public StudentModel AddDoneHomeWork(string homeWork)
        {
            DoneHomeWorks.Add(homeWork);
            return this;
        }


    }

}
