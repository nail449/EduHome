using EduHome.DataAccessLayer;
using EduHome.Extensions;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        
        public CourseController(AppDbContext db,        
                                IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _db.Courses.Include(x=>x.CourseDetails).ToListAsync();
            return View(courses);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (!ModelState.IsValid)        
            {
                return View();
            }

            bool isExist = await _db.Courses.AnyAsync(x=>x.Name==course.Name&& x.ID==course.ID);
            if (isExist)
            {
                ModelState.AddModelError("Name", "There is already a course of this name");
                return View(isExist);
            }

            
            if (course.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please select photo");
                return View(course);
            }
            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select photo...!");
                return View(course);
            }
            if (course.Photo.IsMaxLength(1000))
            {
                ModelState.AddModelError("Photo", "Please Max Length 500 !");
                return View(course);
            }
            if (course.CourseDetails.AboutCourse==null)
            {
                ModelState.AddModelError("CourseDetails.AboutCourse", "Please fill in the box correctly");
                return View(course);
            }
            if (course.CourseDetails.Assesments == null)
            {
                ModelState.AddModelError("CourseDetails.Assesments", "Please Fill in the box correctly ! ");
                return View(course);

            }
            if (course.CourseDetails.Certification == null)
            {
                ModelState.AddModelError("CourseDetails.Certification","Fill in the box correctly...!");
                return View(course);

            }
            if (course.CourseDetails.HowToApply == null)
            {
                ModelState.AddModelError("CourseDetails.HowToApply", "Please Fill in the box correctly !!!");
                return View(course);

            }
            
            if (course.CourseDetails.Language == null)
            {
                ModelState.AddModelError("CourseDetails.Language", "Fill in the box correctly!!!!!");
                return View(course);

            }
            
            string folder = Path.Combine(_env.WebRootPath, "img", "course");
            course.Image = await course.Photo.SaveImage(folder);



            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Course");
        }
        #endregion
        #region Detail
       /* public async Task<IActionResult> Detail(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Course course = await _db.Courses.Include(x=>x.CourseDetails).FirstOrDefaultAsync(x => x.ID == ID);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }*/
        #endregion
        #region Delete, Activate

        public async Task<IActionResult> Delete(int? ID )
        {
            if (ID == null)
            {
                return NotFound();
            }

            Course course = await _db.Courses.FirstOrDefaultAsync(x=>x.ID==ID);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeletePost(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.ID == ID);
            if (course == null)
            {
                return NotFound();
            }
            course.IsDeactive = true;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.ID == ID);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Activate")]
        public async Task<IActionResult> ActivateAsync(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.ID == ID);
            if (course == null)
            {
                return NotFound();
            }
            course.IsDeactive = false;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion
        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Courses = await _db.Courses.Include(x=>x.CourseDetails).Where(x => x.IsDeactive == false).ToListAsync();

            if (id == null)
            {
                return NotFound();
            }
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.ID == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Course course)
        {
            ViewBag.Courses = await _db.Courses.Include(x=>x.CourseDetails).Where(x => x.IsDeactive == false).ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            Course dbcourse = await _db.Courses.Include(x => x.CourseDetails).FirstOrDefaultAsync(x => x.ID == id);
            if (dbcourse == null)  
            {
                return NotFound();
            }

            if (course.Photo != null)
            {
                if (!course.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yalniz wekil secin diger fayllar yox");
                    return View(dbcourse);
                }

                if (course.Photo.IsMaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Weklin olcusu gosterilen olcuden cox ola bilmez");
                    return View(dbcourse);
                }


            }
            string folder = Path.Combine(_env.WebRootPath, "img", "slider");
            dbcourse.Image = await course.Photo.SaveImage(folder);

            dbcourse.Name = course.Name;
            dbcourse.Image = course.Image;
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }
            #endregion
        }
}
