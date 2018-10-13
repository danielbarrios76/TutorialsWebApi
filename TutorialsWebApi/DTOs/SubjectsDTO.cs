using System;
using System.Collections.Generic;

namespace TutorialsWebApi.DTOs
{
    public class SubjectsDTO
    {
        public int Id { get; set; }
        public string SubjectsName { get; set; }

        public List<ClassRoomDTO> ClassRoom { get; set; }
    }
}
