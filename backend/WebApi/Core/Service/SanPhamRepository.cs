using System;
using Core.Base;
using EntityFramework.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Core.Service
{
    public class SanPhamDto
    {
        
        public string TenSanPham { get; set; }
        public string SoDangKy { get; set; }
        public DateTime? HanSuDung  { get; set; }
        public string QuyCach { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? NgaySanXuat { get; set; }
    }
    public interface ISanPhamRepository:IBaseRepository<SanPham>
    {
        bool DeleteSanPham(int maSanPham);
        bool createSanPham(SanPhamDto sanPhamDto);
        IEnumerable<SanPham> getSanPhamCoNgayDangKyTruocNgay(string datetime);
        IEnumerable<SanPham> getSanPhamCoHanSuDungTrenNam(int soNam);
    }
    class SanPhamRepository : BaseRepository<SanPham>, ISanPhamRepository
    {
        private NKSLKContext _nhancongContext;
        private IMapper _mapper;
        public SanPhamRepository(NKSLKContext context, IMapper mapper) : base(context)
        {
            _nhancongContext = context;
            _mapper = mapper;
        }

        public bool createSanPham(SanPhamDto sanPhamDto)
        {
            try
            {
                var entity = _mapper.Map<SanPham>(sanPhamDto);
                base.Create(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
