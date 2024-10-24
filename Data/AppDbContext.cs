using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatFormService.Models;

namespace PlatFormService.Data
{
    public class AppDbContext:DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
         {
            
         }
         public DbSet<Platform> platforms {get;set;}
    }
}