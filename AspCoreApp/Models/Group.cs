using System;
using System.Collections.Generic;

namespace AspCoreApp.Models
{
    public partial class Group
    {
        public Group()
        {
            Student = new HashSet<Student>();
        }

        public int GroupId { get; set; }
        public int? CourseId { get; set; }
        public string Name { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
