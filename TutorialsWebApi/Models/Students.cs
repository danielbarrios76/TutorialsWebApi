﻿using System;
using System.Collections.Generic;

namespace TutorialsWebApi.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentsClassRoom = new HashSet<StudentsClassRoom>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<StudentsClassRoom> StudentsClassRoom { get; set; }
    }
}
