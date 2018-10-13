using System;
using System.Collections.Generic;

namespace TutorialsWebApi.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            ClassRoom = new HashSet<ClassRoom>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<ClassRoom> ClassRoom { get; set; }
    }
}
