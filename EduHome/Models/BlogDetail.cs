using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class BlogDetail
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Blog Blog { get; set; }
        [ForeignKey("Blog")]
        public int BlogID { get; set; }
    }
}
