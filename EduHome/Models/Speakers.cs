using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Speakers
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool IsDeactive { get; set; }

        public List<Event> Events { get; set; }
    }
}
