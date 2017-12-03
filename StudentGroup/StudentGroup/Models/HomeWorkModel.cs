using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroup.Models
{
    public class HomeWorkModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }
    }
}
