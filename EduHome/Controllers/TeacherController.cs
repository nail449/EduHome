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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;
        public TeacherController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers =await _db.Teachers.Include(x=>x.TeacherPosition).ToListAsync();
            return View(teachers);
        }
        public async Task<IActionResult> Detail(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Teacher teacher = await _db.Teachers.Where(x => x.ID == ID).Include(x => x.TeacherDetail).Include(x => x.TeacherPosition).FirstOrDefaultAsync();
            if (teacher==null)
            {
                return NotFound();
            }
            return View(teacher);
        }
    }
}
