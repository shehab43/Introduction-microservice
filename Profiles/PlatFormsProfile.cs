using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlatFormService.Dtos;
using PlatFormService.Models;

namespace PlatFormService.Profiles
{
    public class PlatFormsProfile:Profile
    {
        public PlatFormsProfile()
        {
            CreateMap<Platform,PlatFormReadDto>();

            CreateMap<PlatFormCreateDto,Platform>();
        }
    }
}