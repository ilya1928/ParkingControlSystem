using AutoMapper;
using ParkingControl.Database.Models;
using ParkingControl.Shared.DTO.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControl.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateReportRequest, Report>(MemberList.Source);
        }
    }
}
