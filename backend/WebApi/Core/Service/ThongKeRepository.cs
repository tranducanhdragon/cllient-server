using Core.Base;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class CongViecMaxSLK
    {
        public string TenCongViec { get; set; }
        public int SoLuong { get; set; }
    }
    public class NKSLKCongNhan{
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public int GioiTinh { get; set; }
        public int NgayNKSLK { get; set; }
        public int MaNKSLK { get; set; }
        public int MaCongViec { get; set; }
    }
    public class NhanCongThang
    {
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string PhongBan { get; set; }
        public string ChucVu { get; set; }
        public int GioiTinh { get; set; }
        public int NgayNKSLK { get; set; }
        public int MaNhanCong { get; set; }
    }
    public interface IThongKeRepository
    {
        CongViecMaxSLK GetCongViecMaxSLK();
        CongViec GetCongViecDonGiaMax();
        CongViec GetCongViecDonGiaMin();
        IEnumerable<CongViec> GetCongViecLonHonDonTB();
        IEnumerable<CongViec> GetCongViecNhoHonDonTB();
        IEnumerable<NhanCongThang> GetNhanCongsThang(int thang);
        IEnumerable<NKSLKCongNhan> GetNKSLKCongNhanThang(int thang);
    }
    public class ThongKeRepository : IThongKeRepository
    {
        private NKSLKContext _thongkeContext;
        public ThongKeRepository(NKSLKContext context)
        {
            _thongkeContext = context;
        }
        public CongViecMaxSLK GetCongViecMaxSLK()
        {
            var result = Helper.RawSqlQuery(
            "with NKSLK_SoLuong(maNKSLK, maCongViec, soLuong) as ( " +
            "select NKSLK_ChiTiet.maNKSLK, DanhMucKhoan_ChiTiet.maCongViec, count(NKSLK_ChiTiet.maNKSLK) as soLuong from NKSLK_ChiTiet join DanhMucKhoan_ChiTiet " +
            "on NKSLK_ChiTiet.maNKSLK = DanhMucKhoan_ChiTiet.maNKSLK " +
            "group by NKSLK_ChiTiet.maNKSLK, DanhMucKhoan_ChiTiet.maCongViec) " +
            "select top(1) * from "+
            "(select CongViec.tenCongViec, max(NKSLK_SoLuong.soLuong) as so_luong from CongViec join NKSLK_SoLuong "+
            "on CongViec.maCongViec = NKSLK_SoLuong.maCongViec " +
            "group by CongViec.tenCongViec)CV " +
            "order by CV.so_luong desc ",
            x => new CongViecMaxSLK { TenCongViec = (string)x[0], SoLuong = (int)x[1] }).FirstOrDefault();
            return result;
        }
        public CongViec GetCongViecDonGiaMax()
        {
            var result = Helper.RawSqlQuery("with NKSLK_MAX_DONGIA(maxDonGia) as ( " +
            "select max(CongViec.donGia) from CongViec) " +
            "select * from CongViec, NKSLK_MAX_DONGIA " +
            "where CONVERT(decimal(10, 2), CongViec.donGia) = CONVERT(decimal(10, 2), NKSLK_MAX_DONGIA.maxDonGia)",
            x => new CongViec {
                TenCongViec = (string)x[0],
                DinhMucKhoan = (double)x[1],
                DonViKhoan = (string)x[2],
                HeSoKhoan = (double)x[3],
                DinhMucLaoDong = (double)x[4],
                DonGia = (double)x[5],
                MaCongViec = (int)x[6]
            }).FirstOrDefault();
            return result;
        }
        public CongViec GetCongViecDonGiaMin()
        {
            var result = Helper.RawSqlQuery("with NKSLK_MIN_DONGIA(minDonGia) as ( " +
            "select min(CongViec.donGia) from CongViec) " +
            "select * from CongViec, NKSLK_MIN_DONGIA " +
            "where CONVERT(decimal(10, 2), CongViec.donGia) = CONVERT(decimal(10, 2), NKSLK_MIN_DONGIA.minDonGia)",
            x => new CongViec
            {
                TenCongViec = (string)x[0],
                DinhMucKhoan = (double)x[1],
                DonViKhoan = (string)x[2],
                HeSoKhoan = (double)x[3],
                DinhMucLaoDong = (double)x[4],
                DonGia = (double)x[5],
                MaCongViec = (int)x[6]
            }).FirstOrDefault();
            return result;
        }
        public IEnumerable<CongViec> GetCongViecLonHonDonTB()
        {
            var result = Helper.RawSqlQuery("with NKSLK_AVG_DONGIA(avgDonGia) as (" +
            "select avg(donGia)from CongViec ) " +
            "select * from CongViec, NKSLK_AVG_DONGIA where CongViec.donGia > NKSLK_AVG_DONGIA.avgDonGia; ",
            x => new CongViec
            {
                TenCongViec = (string)x[0],
                DinhMucKhoan = (double)x[1],
                DonViKhoan = (string)x[2],
                HeSoKhoan = (double)x[3],
                DinhMucLaoDong = (double)x[4],
                DonGia = (double)x[5],
                MaCongViec = (int)x[6]
            });
            return result;
        }
        public IEnumerable<CongViec> GetCongViecNhoHonDonTB()
        {
            var result = Helper.RawSqlQuery("with NKSLK_AVG_DONGIA(avgDonGia) as (" +
            "select avg(donGia)from CongViec ) " +
            "select * from CongViec, NKSLK_AVG_DONGIA where CongViec.donGia <= NKSLK_AVG_DONGIA.avgDonGia; ",
            x => new CongViec
            {
                TenCongViec = (string)x[0],
                DinhMucKhoan = (double)x[1],
                DonViKhoan = (string)x[2],
                HeSoKhoan = (double)x[3],
                DinhMucLaoDong = (double)x[4],
                DonGia = (double)x[5],
                MaCongViec = (int)x[6]
            });
            return result;
        }

        public IEnumerable<NhanCongThang> GetNhanCongsThang(int thang)
        {
            var result = Helper.RawSqlQuery("with NKSLK_Ngay(maNhanCong, maNKSLK, ngayNKSLK) as( " +
                "select NhanCong.maNhanCong, NKSLK_ChiTiet.maNKSLK, datepart(month, NKSLK.ngay) from NhanCong " +
                "join NKSLK_ChiTiet on NhanCong.maNhanCong = NKSLK_ChiTiet.maNhanCong " +
                "join NKSLK on NKSLK_ChiTiet.maNKSLK = NKSLK.maNKSLK) " +
                "select NhanCong.hoTen, " +
                "NhanCong.ngaySinh, " +
                "NhanCong.phongBan, " +
                "NhanCong.chucVu, " +
                "NhanCong.gioiTinh, " +
                "NKSLK_Ngay.ngayNKSLK, " +
                "NhanCong.maNhanCong " +
                "from NhanCong " +
                "join NKSLK_Ngay " +
                "on NhanCong.maNhanCong = NKSLK_Ngay.maNhanCong " +
                "join NKSLK_ChiTiet " +
                "on NKSLK_ChiTiet.maNKSLK = NKSLK_Ngay.maNKSLK " +
                "where NKSLK_Ngay.ngayNKSLK = " + thang.ToString() +
                " group by NhanCong.hoTen, " +
                "NhanCong.ngaySinh, " +
                "NhanCong.phongBan, " +
                "NhanCong.chucVu, " +
                "NhanCong.gioiTinh, " +
                "NKSLK_Ngay.ngayNKSLK, " +
                "NhanCong.maNhanCong; ",
                x => new NhanCongThang
                {
                    HoTen=(string)x[0],
                    NgaySinh=(x[1] == DBNull.Value? new DateTime() : (DateTime?)x[1]),
                    PhongBan=(string)x[2],
                    ChucVu=(string)x[3],
                    GioiTinh=(int)x[4],
                    NgayNKSLK=(int)x[5],
                    MaNhanCong=(int)x[6]
                });
            return result;
        }

        public IEnumerable<NhanCong> GetNhanCongs(int thang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NKSLKCongNhan> GetNKSLKCongNhanThang(int thang)
        {
            throw new NotImplementedException();
        }
    }
}
