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
    public class NKSLKChiTiet
    {
        public int? MaNkslk { get; set; }
        public int? MaNhanCong { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }
        public int MaChiTiet { get; set; }
        public DateTime? Ngay { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public string QueQuan { get; set; }
        public int? GioiTinh { get; set; }

    }
    public class NKSLKChiTietCreate
    {
        public int? MaNhanCong { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }
        public int? MaCongViec { get; set; }
    }
    public interface INKSLKRepository : IBaseRepository<Nkslk>
    {
        bool DeleteNKSLK(int ma);
        IEnumerable<NKSLKChiTiet> GetAllNKSLKChiTiets();
        bool CreateNKSLK(NKSLKChiTietCreate nkslkchitiet);
    }
    public class NKSLKRepository : BaseRepository<Nkslk>, INKSLKRepository
    {
        private NKSLKContext _NKSLKContext;
        private IMapper _mapper;
        public NKSLKRepository(NKSLKContext context, IMapper mapper) : base(context)
        {
            _NKSLKContext = context;
            _mapper = mapper;
        }
        public bool DeleteNKSLK(int ma)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<NKSLKChiTiet> GetAllNKSLKChiTiets()
        {
            var result = from nkslk in _NKSLKContext.Nkslks.ToList()
                         join nkslk_chitiet in _NKSLKContext.NkslkChiTiets.ToList()
                         on nkslk.MaNkslk equals nkslk_chitiet.MaNkslk
                         join nhancong in _NKSLKContext.NhanCongs.ToList()
                         on nkslk_chitiet.MaNhanCong equals nhancong.MaNhanCong
                         select new NKSLKChiTiet
                         {
                             MaNkslk = nkslk.MaNkslk,
                             GioBatDau = nkslk_chitiet.GioBatDau,
                             GioKetThuc = nkslk_chitiet.GioKetThuc,
                             MaNhanCong = nkslk_chitiet.MaNhanCong,
                             MaChiTiet = nkslk_chitiet.MaChiTiet,
                             Ngay = nkslk.Ngay,
                             HoTen = nhancong.HoTen,
                             ChucVu = nhancong.ChucVu,
                             GioiTinh = nhancong.GioiTinh,
                             NgaySinh = nhancong.NgaySinh,
                             PhongBan = nhancong.PhongBan,
                             QueQuan = nhancong.QueQuan
                         };
            return result.ToList();
        }
        public bool CreateNKSLK(NKSLKChiTietCreate nkslkchitiet)
        {
            try
            {
                var nkslk = new Nkslk();
                nkslk.Ngay = DateTime.Now;
                _NKSLKContext.Nkslks.Add(nkslk);
                _NKSLKContext.SaveChanges();

                var nkslkchitiet_entity = _mapper.Map<NkslkChiTiet>(nkslkchitiet);
                nkslkchitiet_entity.MaNkslk = nkslk.MaNkslk;
                _NKSLKContext.NkslkChiTiets.Add(nkslkchitiet_entity);
                _NKSLKContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
