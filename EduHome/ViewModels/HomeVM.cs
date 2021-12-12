using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }

        public List<Course> Courses { get; set; }
        
        public List<CourseDetail> CourseDetails { get; set; }
        
        public List<Event> Events { get; set; }
        public EventDetail EventDetail { get; set; }
        public List<Speakers> Speakers { get; set; }
        public About About { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
