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
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext _db)
        {
            this._db = _db;
        }
        public async Task<IActionResult> Index()
        {
            About about = await _db.Abouts.FirstOrDefaultAsync();
            return View(about);
        }

    }
}
