using System;
using Core.Base;
using EntityFramework.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{

    public interface ISanPhamRepository:IBaseRepository<SanPham>
    {
        bool DeleteSanPham(int maSanPham);
        IEnumerable<SanPham> getSanPhamCoNgayDangKyTruocNgay(string datetime);
        IEnumerable<SanPham> getSanPhamCoHanSuDungTrenNam(int soNam);
    }
    class SanPhamRepository : BaseRepository<SanPham>, ISanPhamRepository
    {
        private NKSLKContext _nhancongContext;
        public SanPhamRepository(NKSLKContext context) : base(context)
        {
            _nhancongContext = context;
        }

        public bool DeleteSanPham(int maSanPham)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SanPham> getSanPhamCoHanSuDungTrenNam(int soNam)
        {
            string sql = "select * from SanPham where  DATEDIFF(DAY, SanPham.ngaySanXuat, SanPham.hanSuDung) > " + (365 * soNam);
            var result = Helper.RawSqlQuery(sql,
            value => new SanPham
            {
                TenSanPham = (string)value[0],
                SoDangKy = (string)value[1],
                HanSuDung = (DateTime)value[2],
                QuyCach = value[3] is System.DBNull ? "Không có" : (string)value[3],
                NgayDangKy = (DateTime)value[4],
                MaSanPham = (int)value[5],
                NgaySanXuat = (DateTime)value[6]
            });
            return result;
        }

        public IEnumerable<SanPham> getSanPhamCoNgayDangKyTruocNgay(string datetime)
        {
            string sql = "select * from SanPham where ngayDangKy < '" + datetime + "'";
            var result = Helper.RawSqlQuery(sql,
            value => new SanPham
            {
                TenSanPham = (string) value[0],
                SoDangKy = (string) value[1],
                HanSuDung = (DateTime)value[2],
                QuyCach = value[3] is System.DBNull ? "Không có" : (string) value[3] ,
                NgayDangKy = (DateTime) value[4],
                MaSanPham = (int) value[5],
                NgaySanXuat = (DateTime) value[6]
            });
            return result;
        }
    }
}
