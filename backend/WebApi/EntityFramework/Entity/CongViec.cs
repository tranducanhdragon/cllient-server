using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Table("CongViec")]
    [Index(nameof(DonViKhoan), Name = "ind_donViKhoan")]
    [Index(nameof(TenCongViec), Name = "unique_tenCongViec", IsUnique = true)]
    public partial class CongViec
    {
        public CongViec()
        {
            DanhMucKhoanChiTiets = new HashSet<DanhMucKhoanChiTiet>();
        }

        [Column("tenCongViec")]
        [StringLength(50)]
        public string TenCongViec { get; set; }
        [Column("dinhMucKhoan")]
        public double? DinhMucKhoan { get; set; }
        [Column("donViKhoan")]
        [StringLength(20)]
        public string DonViKhoan { get; set; }
        [Column("heSoKhoan")]
        public double? HeSoKhoan { get; set; }
        [Column("dinhMucLaoDong")]
        public double? DinhMucLaoDong { get; set; }
        [Column("donGia")]
        public double? DonGia { get; set; }
        [Key]
        [Column("maCongViec")]
        public int MaCongViec { get; set; }

        [InverseProperty(nameof(DanhMucKhoanChiTiet.MaCongViecNavigation))]
        public virtual ICollection<DanhMucKhoanChiTiet> DanhMucKhoanChiTiets { get; set; }
    }
}
