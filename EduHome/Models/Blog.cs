using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int IconComment { get; set; }
        public bool IsDeactive { get; set; }

        public string Title { get; set; }
        public BlogDetail BlogDetail { get; set; }
    }
}
