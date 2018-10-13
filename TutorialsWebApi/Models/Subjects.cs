using System;
using System.Collections.Generic;

namespace TutorialsWebApi.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            ClassRoom = new HashSet<ClassRoom>();
        }

        public int Id { get; set; }
        public string SubjectsName { get; set; }

        public ICollection<ClassRoom> ClassRoom { get; set; }
    }
}
