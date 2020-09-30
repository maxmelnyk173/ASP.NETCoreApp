using System;

namespace AspCoreApp.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int? GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Group Group { get; set; }
    }
}
