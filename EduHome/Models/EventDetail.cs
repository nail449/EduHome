using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class EventDetail
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
        [ForeignKey("Event")]
        public int EventID { get; set; }
    }
}
