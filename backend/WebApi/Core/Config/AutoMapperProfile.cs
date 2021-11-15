using AutoMapper;
using Core.Service;
using EntityFramework.Entity;

namespace Core.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CongViec, CongViecDto>();
            CreateMap<CongViecDto, CongViec>();
        }
    }
}
