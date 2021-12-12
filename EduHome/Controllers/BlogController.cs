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
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext _db)
        {
            this._db = _db;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            return View(blogs);
        }
        public async Task<IActionResult> Detail(int? ID)
        {
            if (ID==null)
            {
                return NotFound();
            }
            Blog blog =await _db.Blogs.Where(x=>x.ID==ID).Include(x => x.BlogDetail).FirstOrDefaultAsync();
            if (blog==null)
            {
                return NotFound();
            }
            return View(blog);
        }
    }
}
