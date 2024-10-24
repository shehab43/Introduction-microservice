using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlatFormService.Data;
using PlatFormService.Dtos;
using PlatFormService.Models;

namespace PlatFormService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : Controller
    {
        private readonly IPlatFormRepo _Reposatory;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatFormRepo Reposatory, IMapper mapper)
        {
            _Reposatory = Reposatory;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatFormReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Get Platforms....");
            var platformItem = _Reposatory.GetAllPlatForm();

            return Ok(_mapper.Map<IEnumerable<PlatFormReadDto>>(platformItem));
        }

        [HttpGet("{id}",Name = "GetPlatformById")]
        public ActionResult<PlatFormReadDto> GetPlatformById(int id)
        {
            var platformItem = _Reposatory.GetPlatformById(id);
            if(platformItem != null)
            {
                return Ok(_mapper.Map<PlatFormReadDto>(platformItem));

            }
            return NotFound();
       
        }

        [HttpPost]
        public ActionResult<PlatFormReadDto> CreatePlatform(PlatFormCreateDto platFormCreate)
        {
           var platformModel =  _mapper.Map<Platform>(platFormCreate);
           _Reposatory.CreatePlatForm(platformModel);
           _Reposatory.SaveChanges();


           var PlatFormReadDto = _mapper.Map<PlatFormReadDto>(platformModel);

           return CreatedAtRoute(nameof(GetPlatformById), new {id = PlatFormReadDto.Id},PlatFormReadDto);

        }
    }
}