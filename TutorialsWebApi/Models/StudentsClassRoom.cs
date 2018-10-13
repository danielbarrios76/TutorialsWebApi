using System;
using System.Collections.Generic;

namespace TutorialsWebApi.Models
{
    public partial class StudentsClassRoom
    {
        public int Id { get; set; }
        public int ClassRoomId { get; set; }
        public int StudentsId { get; set; }

        public ClassRoom ClassRoom { get; set; }
        public Students Students { get; set; }
    }
}
