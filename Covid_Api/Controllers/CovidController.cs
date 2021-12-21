using AutoMapper;
using Covid_Api.BLL;
using Covid_Api.Dto;
using Covid_Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICovidService _covidService;
        public CovidController(ICovidService covidService, IMapper mapper)
        {

            _covidService = covidService;
            _mapper = mapper;
        }


        

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await _covidService.getAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CovidDto data)
        {

            return Ok(await _covidService.AddDataAsync(data));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {

            return Ok(await _covidService.getByIdAsync(Id));
        }

        [HttpPut]
        public async Task<IActionResult> Put(string Id, [FromBody] CovidDto data)
        {

            return Ok(await _covidService.UpdateDataAsync(data));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {

            return Ok(await _covidService.DeleteDataAsync(Id));
        }



    }
}
