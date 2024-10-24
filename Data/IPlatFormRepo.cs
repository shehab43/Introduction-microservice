using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatFormService.Models;

namespace PlatFormService.Data
{
    public interface IPlatFormRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatForm();

        Platform GetPlatformById(int id);

        void CreatePlatForm(Platform plat);
    }
}