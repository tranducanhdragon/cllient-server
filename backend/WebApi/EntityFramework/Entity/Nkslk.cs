using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Table("NKSLK")]
    public partial class Nkslk
    {
        public Nkslk()
        {
            DanhMucKhoanChiTiets = new HashSet<DanhMucKhoanChiTiet>();
            NkslkChiTiets = new HashSet<NkslkChiTiet>();
        }

        [Column("ngay", TypeName = "date")]
        public DateTime? Ngay { get; set; }
        [Key]
        [Column("maNKSLK")]
        public int MaNkslk { get; set; }

        [InverseProperty(nameof(DanhMucKhoanChiTiet.MaNkslkNavigation))]
        public virtual ICollection<DanhMucKhoanChiTiet> DanhMucKhoanChiTiets { get; set; }
        [InverseProperty(nameof(NkslkChiTiet.MaNkslkNavigation))]
        public virtual ICollection<NkslkChiTiet> NkslkChiTiets { get; set; }
    }
}
