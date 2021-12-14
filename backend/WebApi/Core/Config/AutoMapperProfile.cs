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
            //them map san pham
            CreateMap<SanPham, SanPhamDto>();
            CreateMap<SanPhamDto, SanPham>();

            CreateMap<NkslkChiTiet, NKSLKChiTietCreate>();
            CreateMap<NKSLKChiTietCreate, NkslkChiTiet>();
        }
    }
}
