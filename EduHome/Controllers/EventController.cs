using EduHome.DataAccessLayer;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _db;
        public EventController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _db.Events.ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Event evnt = await _db.Events.Where(x => x.ID ==Id).Include(x => x.EventDetail).Include(x => x.Speakers).FirstOrDefaultAsync();
            if (evnt == null)
            {
                return NotFound();
            } 
            return View(evnt);
        }

     

    }
}
