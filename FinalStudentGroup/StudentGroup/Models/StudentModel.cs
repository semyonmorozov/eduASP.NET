using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentGroup.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "First name required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student card number required")]
        [Range(10000000, 99999999, ErrorMessage = "Student card number must be eight digits")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentCardNumber { get; set; }

        [Required(ErrorMessage = "Email address required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
    
}
