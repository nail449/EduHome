using EduHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DataAccessLayer
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<Event>  Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<TeacherPosition> TeacherPositions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }


    
    }
}
