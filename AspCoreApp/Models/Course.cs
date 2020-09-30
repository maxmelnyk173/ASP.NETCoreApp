using System;
using System.Collections.Generic;

namespace AspCoreApp.Models
{
    public partial class Course
    {
        public Course()
        {
            Group = new HashSet<Group>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Group> Group { get; set; }
    }
}
