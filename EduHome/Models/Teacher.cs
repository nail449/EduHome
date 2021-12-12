using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string FullName { get; set; }
        public string Facebook { get; set; }
        public string Pinterest { get; set; }
        public string Violet { get; set; }
        public string Twitter { get; set; }
        public bool IsDeactive { get; set; }

        public TeacherDetail TeacherDetail { get; set; }
        public TeacherPosition TeacherPosition { get; set; }
        public int TeacherPositionID { get; set; }
    }
}
