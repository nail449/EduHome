using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Image { get; set; }
        [Required] 
        public string Name { get; set; }
        public bool IsDeactive { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public CourseDetail CourseDetails { get; set; }

    }
}
