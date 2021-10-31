using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Table("DanhMucKhoan_ChiTiet")]
    [Index(nameof(MaCongViec), Name = "ind_maCongViec")]
    [Index(nameof(MaNkslk), Name = "ind_maNKSLK_2")]
    [Index(nameof(MaSanPham), Name = "ind_maSanPham")]
    public partial class DanhMucKhoanChiTiet
    {
        [Column("maNKSLK")]
        public int? MaNkslk { get; set; }
        [Column("maCongViec")]
        public int? MaCongViec { get; set; }
        [Column("sanLuongThucTe")]
        public double? SanLuongThucTe { get; set; }
        [Column("soLoSanPham")]
        [StringLength(20)]
        public string SoLoSanPham { get; set; }
        [Column("maSanPham")]
        public int? MaSanPham { get; set; }
        [Key]
        [Column("maChiTiet")]
        public int MaChiTiet { get; set; }

        [ForeignKey(nameof(MaCongViec))]
        [InverseProperty(nameof(CongViec.DanhMucKhoanChiTiets))]
        public virtual CongViec MaCongViecNavigation { get; set; }
        [ForeignKey(nameof(MaNkslk))]
        [InverseProperty(nameof(Nkslk.DanhMucKhoanChiTiets))]
        public virtual Nkslk MaNkslkNavigation { get; set; }
        [ForeignKey(nameof(MaSanPham))]
        [InverseProperty(nameof(SanPham.DanhMucKhoanChiTiets))]
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
