using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherPosition
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
