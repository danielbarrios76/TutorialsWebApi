using System;
using System.Collections.Generic;

namespace TutorialsWebApi.DTOs
{
    public class ClassRoomDTO
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int TeachersId { get; set; }
        public int SubjectsId { get; set; }

        public SubjectsDTO Subjects { get; set; }
        public TeachersDTO Teachers { get; set; }
        public List<StudentsClassRoomDTO> StudentsClassRoom { get; set; }
    }
}
