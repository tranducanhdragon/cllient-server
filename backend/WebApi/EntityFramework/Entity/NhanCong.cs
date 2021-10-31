using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Table("NhanCong")]
    [Index(nameof(ChucVu), Name = "ind_chucVu")]
    [Index(nameof(PhongBan), Name = "ind_phongBan")]
    public partial class NhanCong
    {
        public NhanCong()
        {
            NkslkChiTiets = new HashSet<NkslkChiTiet>();
        }

        [Column("hoTen")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Column("ngaySinh", TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        [Column("phongBan")]
        [StringLength(50)]
        public string PhongBan { get; set; }
        [Column("chucVu")]
        [StringLength(50)]
        public string ChucVu { get; set; }
        [Column("queQuan")]
        [StringLength(50)]
        public string QueQuan { get; set; }
        [Column("luongBaoHiem")]
        public double? LuongBaoHiem { get; set; }
        [Key]
        [Column("maNhanCong")]
        public int MaNhanCong { get; set; }
        [Column("gioiTinh")]
        public int? GioiTinh { get; set; }

        [InverseProperty(nameof(NkslkChiTiet.MaNhanCongNavigation))]
        public virtual ICollection<NkslkChiTiet> NkslkChiTiets { get; set; }
    }
}
