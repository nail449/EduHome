using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _db.Sliders.ToListAsync(),
                Courses = await _db.Courses.Where(x=>x.IsDeactive==false).ToListAsync(),
                CourseDetails = await _db.CourseDetails.ToListAsync(),
                Events = await _db.Events.ToListAsync(),
                EventDetail = await _db.EventDetails.FirstOrDefaultAsync(),
                About = await _db.Abouts.FirstOrDefaultAsync(),
                Blogs = await _db.Blogs.ToListAsync(),

            };
            return View(homeVM);
        }

    }
}
