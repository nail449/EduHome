using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherDetail
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public string Image { get; set; }
        public string AboutMe { get; set; }
        public string DEGREE { get; set; }
        public string EXPERIENCE { get; set; }
        public string HOBBIES { get; set; }
        public string FACULTY { get; set; }
        public string MAILME { get; set; }
        public string MAKECALL{ get; set; }
        public string SKYPE { get; set; }
        public double Language { get; set; }
        public double TeamLeader { get; set; }
        public double Development { get; set; }
        public double Design { get; set; }
        public double Innovation { get; set; }
        public double Communication { get; set; }
    }
}
