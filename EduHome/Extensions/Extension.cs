using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Extensions
{
    public static class Extension
    {
        public static bool IsImage(this IFormFile Photo)
        {
            return Photo.ContentType.Contains("image/");
           
        }
        public static bool IsMaxLength(this IFormFile file, int kb)
        {
            return (file.Length / 1024 > kb);

        }

        public static async Task<string> SaveImage(this IFormFile file, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folder, fileName);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
