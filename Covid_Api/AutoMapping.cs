using AutoMapper;
using Covid_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CovidModel, Dto.CovidDto>();
           CreateMap<Dto.CovidDto, Dto.CovidDtoDynamo>(); // means you want to map from CovidModel to CovidDto
        }
    }
}
