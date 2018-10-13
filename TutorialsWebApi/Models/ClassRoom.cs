using System;
using System.Collections.Generic;

namespace TutorialsWebApi.Models
{
    public partial class ClassRoom
    {
        public ClassRoom()
        {
            StudentsClassRoom = new HashSet<StudentsClassRoom>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public int TeachersId { get; set; }
        public int SubjectsId { get; set; }

        public Subjects Subjects { get; set; }
        public Teachers Teachers { get; set; }
        public ICollection<StudentsClassRoom> StudentsClassRoom { get; set; }
    }
}
