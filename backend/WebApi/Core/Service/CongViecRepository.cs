using AutoMapper;
using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
  
    public class CongViecDto
    {
        public string TenCongViec { get; set; }
        public double? DinhMucKhoan { get; set; }
        public string DonViKhoan { get; set; }
        public double? HeSoKhoan { get; set; }
        public double? DinhMucLaoDong { get; set; }
        public double? DonGia { get; set; }
    }
    public class CongViecDtoUpdate
    {
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; }
        public double? DinhMucKhoan { get; set; }
        public string DonViKhoan { get; set; }
        public double? HeSoKhoan { get; set; }
        public double? DinhMucLaoDong { get; set; }
        public double? DonGia { get; set; }
    }
    public interface ICongViecRepository : IBaseRepository<CongViec>
    {
        bool DeleteCongViecWithId(int maCongViec);
        bool CreateCongViec(CongViecDto dto);
        bool UpdateCongViec(int maCongViec, string tenCongViec, double? dinhMucKhoan, string donViKhoan, double? heSoKhoan, double? dinhMucLaoDong);
    }

    class CongViecRepository : BaseRepository<CongViec>, ICongViecRepository
    {
        private NKSLKContext _nhancongContext;
        private IMapper _mapper;
        public CongViecRepository(NKSLKContext context, IMapper mapper) : base(context)
        {
            _nhancongContext = context;
            _mapper = mapper;
        }
        public bool CreateCongViec(CongViecDto dto)
        {
            var entity = _mapper.Map<CongViec>(dto);
            base.Create(entity);
            return true;
        }
        public bool DeleteCongViecWithId(int maCongViec)
        {
            var result = Helper.RawSqlQuery("delete from CongViec where CongViec.maCongViec = " + maCongViec,
                x => new CongViecDto());

            Console.WriteLine("result " + result);

            return result == null ?  false :  true;
        }

        public bool UpdateCongViec(int maCongViec, string tenCongViec, double? dinhMucKhoan, string donViKhoan, double? heSoKhoan, double? dinhMucLaoDong)
        {
            var result = Helper.RawSqlQuery("update CongViec set "
                + "tenCongViec = N'" + tenCongViec +"'"
                + ", dinhMucKhoan = " + dinhMucKhoan
                + ", donViKhoan = N'" + donViKhoan +"'"
                + ", heSoKhoan = " + heSoKhoan
                + ", dinhMucLaoDong = " + dinhMucLaoDong
                + " where maCongViec = " + maCongViec,
                x => new CongViecDtoUpdate());

            Console.WriteLine("result " + result);

            return result == null ? false : true;
        }
    }
}
