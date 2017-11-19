using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentGroup.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int StudentCardNumber { get; set; }

        public string EmailAddress { get; set; }

        public List<string> DoneHomeWorks = new List<string>();

        public StudentModel AddDoneHomeWork(string homeWork)
        {
            DoneHomeWorks.Add(homeWork);
            return this;
        }


    }

}
