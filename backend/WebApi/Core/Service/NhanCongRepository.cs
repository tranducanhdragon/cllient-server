using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        void EditNhanCong(NhanCongDto nhanCong);
        IEnumerable<NhanCong> nhanCongSapNghiHuu();
        IEnumerable<NhanCong> nhanCong30_45();
        IEnumerable<NhanCong> nhanCongCa3();
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
                if (nc == null) { return false; }
                _nhancongContext.NhanCongs.Remove(nc);
                _nhancongContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException sqlEx)
            {
                throw sqlEx;
                return false;
            }
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
        public string convertToString(object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch
            {
                return "NULL";
            }
        }
        public DateTime convertToDateTime(object obj)
        {
            try
            {
                DateTime number1;
                bool success = DateTime.TryParse(obj.ToString(), out number1);
                if (success)
                {
                    return number1;
                }
                else
                {
                    return new DateTime();
                }
            }
            catch
            {
                return new DateTime();
            }
        }
        public bool canDeleteNhanCong(int id)
        {
            return false;
        }

        public IEnumerable<NhanCong> nhanCong30_45()
        {

            return Helper.RawSqlQuery("with NKSLK_NHANCONG_TUOI(maNhanCong, hoTen, gioiTinh, Tuoi) as ("+

               "SELECT maNhanCong, hoTen, gioiTinh, DATEDIFF(year, NhanCong.ngaySinh, GETDATE()) " +
                "from NhanCong) " +
                " select NhanCong.hoTen, ngaySinh, phongBan, chucVu, queQuan, luongBaoHiem, NhanCong.maNhanCong, NhanCong.gioiTinh, Tuoi " +
                " from NhanCong join NKSLK_NHANCONG_TUOI on NhanCong.maNhanCong = NKSLK_NHANCONG_TUOI.maNhanCong " +
                "where NKSLK_NHANCONG_TUOI.Tuoi > 30 and NKSLK_NHANCONG_TUOI.Tuoi < 45; ", x => new NhanCong
                {
                  
                HoTen = (string)x[0],
                NgaySinh = convertToDateTime(x[1]),
                PhongBan = (string)x[2],
                ChucVu = (string)x[3],
                QueQuan = convertToString(x[4]),
                LuongBaoHiem = (double)x[5],
                MaNhanCong = (int)x[6],
                GioiTinh = (int)x[7]
            }).ToList();
        }
        public IEnumerable<NhanCong> nhanCongCa3()
        {
            return Helper.RawSqlQuery("select hoTen, ngaySinh, phongBan, chucVu, queQuan, luongBaoHiem, NhanCong.maNhanCong, gioiTinh " +
                "from NhanCong join NKSLK_ChiTiet on NhanCong.maNhanCong = NKSLK_ChiTiet.maNhanCong " +
                "where NKSLK_ChiTiet.gioBatDau >= '22:00:00' " +
                "group by hoTen, ngaySinh, phongBan, chucVu, queQuan, luongBaoHiem, NhanCong.maNhanCong, gioiTinh  order by NhanCong.maNhanCong"
                , x => new NhanCong
                {

                    HoTen = (string)x[0],
                    NgaySinh = convertToDateTime(x[1]),
                    PhongBan = (string)x[2],
                    ChucVu = (string)x[3],
                    QueQuan = convertToString(x[4]),
                    LuongBaoHiem = (double)x[5],
                    MaNhanCong = (int)x[6],
                    GioiTinh = (int)x[7]
                }).ToList();
        }

        public IEnumerable<NhanCong> nhanCongSapNghiHuu()
        {

            return Helper.RawSqlQuery("with NKSLK_NHANCONG_TUOI(maNhanCong, hoTen, gioiTinh, Tuoi) as (select maNhanCong, hoTen, gioiTinh, DATEDIFF(year, NhanCong.ngaySinh, GETDATE()) from NhanCong) " +
                "select NhanCong.hoTen, NhanCong.ngaySinh, NhanCong.phongBan, NhanCong.chucVu, NhanCong.queQuan, NhanCong.luongBaoHiem, NhanCong.maNhanCong, NhanCong.gioiTinh from NhanCong join NKSLK_NHANCONG_TUOI on NhanCong.maNhanCong = NKSLK_NHANCONG_TUOI.maNhanCong " +
                "where(NhanCong.gioiTinh = 1 and NKSLK_NHANCONG_TUOI.Tuoi + 1 = 54) OR(NhanCong.gioiTinh = 0 and NKSLK_NHANCONG_TUOI.Tuoi + 1 = 49);"
                , x => new NhanCong
                {
                    HoTen = (string)x[0],
                    NgaySinh = (DateTime)x[1],
                    PhongBan = (string)x[2],
                    ChucVu = (string)x[3],
                    QueQuan = (string)x[4],
                    LuongBaoHiem = (double)x[5],
                    MaNhanCong = (int)x[6],
                    GioiTinh = (int)x[7]
                }).ToList();
        }

        public void EditNhanCong(NhanCongDto enity)
        {
            Helper.SqlCommandRaw("UPDATE NHANCONG SET HoTen = '" + enity.HoTen + "', ngaySinh='" + enity.NgaySinh + "', phongBan='" + enity.PhongBan + "', chucVu='" + enity.ChucVu + "', quequan='" + enity.QueQuan + "', luongBaoHiem=" + enity.LuongBaoHiem + ", GioiTinh=" + enity.GioiTinh + " WHERE maNhanCong="+enity.MaNhanCong);
            _nhancongContext.SaveChanges();
        }
        public void CreateNhanCong(NhanCongDto enity)
        {
            Helper.SqlCommandRaw("INSERT INTO NHANCONG(HoTen, ngaySinh, phongBan, chucVu, quequan, luongBaoHiem, GioiTinh) " + "VALUES ('" + enity.HoTen + "', '" + enity.NgaySinh + "', '" + enity.PhongBan + "', '" + enity.ChucVu + "', '" + enity.QueQuan + "'" +", " + enity.LuongBaoHiem + ", " + enity.GioiTinh + ")");
            _nhancongContext.SaveChanges();
        }
        public bool DeleteNhanCongId(int maNhanCong)
        {
            var result = Helper.RawSqlQuery("delete from NHANCONG where NHANCONG.MaNhanCong = " + maNhanCong,
                x => new CongViecDto());
            _nhancongContext.SaveChanges();
            return true;
        }
    }
}
