using System;
using System.Collections.Generic;

namespace TutorialsWebApi.DTOs
{
    public class StudentsClassRoomDTO
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int StudentsId { get; set; }

        public ClassRoomDTO ClassRoom { get; set; }
        public StudentsDTO Students { get; set; }
    }
}
