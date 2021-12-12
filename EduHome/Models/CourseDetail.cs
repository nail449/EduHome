using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseDetail
    {
        public int ID { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public string AboutCourse { get; set; }
        public string HowToApply { get; set; }
        public string Certification { get; set; }
        public DateTime Starts { get; set; }
        public double Duration { get; set; }
        public double ClassDuration { get; set; }
        public string SkillLevels { get; set; }
        public string Language { get; set; }
        public int Students { get; set; }
        public string Assesments { get; set; }
        public double CourseFee { get; set; } 

    }
}
