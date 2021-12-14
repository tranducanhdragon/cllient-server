using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{

    [Table("NKSLK_ChiTiet")]
    [Index(nameof(MaNkslk), Name = "ind_maNKSLK")]
    [Index(nameof(MaNhanCong), Name = "ind_maNhanCong")]
    public partial class NkslkChiTiet
    {
        [Column("maNKSLK")]
        public int? MaNkslk { get; set; }
        [Column("maNhanCong")]
        public int? MaNhanCong { get; set; }
        [Column("gioBatDau")]
        public TimeSpan? GioBatDau { get; set; }
        [Column("gioKetThuc")]
        public TimeSpan? GioKetThuc { get; set; }
        [Key]
        [Column("maChiTiet")]
        public int MaChiTiet { get; set; }

        [ForeignKey(nameof(MaNhanCong))]
        [InverseProperty(nameof(NhanCong.NkslkChiTiets))]
        public virtual NhanCong MaNhanCongNavigation { get; set; }
        [ForeignKey(nameof(MaNkslk))]
        [InverseProperty(nameof(Nkslk.NkslkChiTiets))]
        public virtual Nkslk MaNkslkNavigation { get; set; }
    }
}
