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
    public interface ICongViecRepository : IBaseRepository<CongViec>
    {
        bool DeleteCongViecWithId(int maCongViec);
        bool CreateCongViec(CongViecDto dto);
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
            return true;
        }
    }
}
