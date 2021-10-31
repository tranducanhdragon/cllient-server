using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.Entity
{
    [Keyless]
    public partial class NgayCong
    {
        [Column("maNhanCong")]
        public int MaNhanCong { get; set; }
        [Column("hoTen")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Column("ngayCong")]
        public int? NgayCong1 { get; set; }
    }
}
