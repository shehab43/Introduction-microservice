using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatFormService.Models;

namespace PlatFormService.Data
{
    public class PlatFormRepo : IPlatFormRepo
    {
        private readonly AppDbContext _context;
        public PlatFormRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatForm(Platform plat)
        {
            if(plat == null) {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatForm()
        {
            return _context.platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0) ;
        }
    }
}