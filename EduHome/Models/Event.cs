using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Venue { get; set; }
        public bool IsDeactive { get; set; }

        public EventDetail EventDetail { get; set; }
        public List<Speakers> Speakers { get; set; }
    }
}
