using EduHome.DataAccessLayer;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {

        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _db.Courses.Where(x=>x.IsDeactive==false).ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Course course = await _db.Courses.Where(x => x.ID == Id).Include(x => x.CourseDetails).FirstOrDefaultAsync();
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public async Task<IActionResult> Search(string key)
        {
            List<Course> courses = await _db.Courses.Where(x=>x.IsDeactive==false).Where(x=>x.Name.Contains(key)).ToListAsync();
            return PartialView("_SearchCoursesPartialView",courses);
        }
      

    }
}
