using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Keyless]
    public partial class NgayCongLamThem
    {
        [Column("maNhanCong")]
        public int MaNhanCong { get; set; }
        [Column("hoTen")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Column("ngayCong", TypeName = "numeric(13, 1)")]
        public decimal? NgayCong { get; set; }
    }
}
