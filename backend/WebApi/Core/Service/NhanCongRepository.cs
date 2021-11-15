using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{

    public class NhanCongDto{
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public string QueQuan { get; set; }
        public double? LuongBaoHiem { get; set; }
        public int MaNhanCong { get; set; }
        public int? GioiTinh { get; set; }
    }

    public interface INhanCongRepository:IBaseRepository<NhanCong>
    {
        bool DeleteNhanCong(int manhancong);
        void CreateNhanCong(NhanCongDto manhancong);
    }
    public class NhanCongRepository : BaseRepository<NhanCong>, INhanCongRepository
    {
        private NKSLKContext _nhancongContext;
        public NhanCongRepository(NKSLKContext context) : base(context)
        {
            _nhancongContext = context;
        }
        public bool DeleteNhanCong(int manhancong)
        {
            try
            {
                var nc = _nhancongContext.NhanCongs.Find(manhancong) as NhanCong;
                _nhancongContext.NhanCongs.Remove(nc);
                _nhancongContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public void CreateNhanCong(NhanCongDto enity)
        {
            Console.WriteLine(enity.HoTen);
            Helper.SqlCommandRaw("INSERT INTO NHANCONG(HoTen, ngaySinh, phongBan, chucVu, quequan, luongBaoHiem, GioiTinh) " + "VALUES ('" + enity.HoTen + "', '" + enity.NgaySinh + "', '" + enity.PhongBan + "', '" + enity.ChucVu + "', '" + enity.QueQuan + "'" +", " + enity.LuongBaoHiem + ", " + enity.GioiTinh + ")");
            _nhancongContext.SaveChanges();
        }
    }
}
