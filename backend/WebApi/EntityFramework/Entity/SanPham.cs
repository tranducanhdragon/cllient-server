using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            DanhMucKhoanChiTiets = new HashSet<DanhMucKhoanChiTiet>();
        }

        [Column("tenSanPham")]
        [StringLength(50)]
        public string TenSanPham { get; set; }
        [Column("soDangKy")]
        [StringLength(20)]
        public string SoDangKy { get; set; }
        [Column("hanSuDung", TypeName = "date")]
        public DateTime? HanSuDung { get; set; }
        [Column("quyCach")]
        [StringLength(20)]
        public string QuyCach { get; set; }
        [Column("ngayDangKy", TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }
        [Key]
        [Column("maSanPham")]
        public int MaSanPham { get; set; }
        [Column("ngaySanXuat", TypeName = "date")]
        public DateTime? NgaySanXuat { get; set; }

        [InverseProperty(nameof(DanhMucKhoanChiTiet.MaSanPhamNavigation))]
        public virtual ICollection<DanhMucKhoanChiTiet> DanhMucKhoanChiTiets { get; set; }
    }
}
