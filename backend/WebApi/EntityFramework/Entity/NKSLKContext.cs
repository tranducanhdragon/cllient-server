using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFramework.Entity
{
    public static class Helper
    {
        public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var context = new NKSLKContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    /*command.CommandTimeout = 100; */// Huynh set them time out
                    context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }
                       

                        return entities;
                    }

                }

            }
        }
    }
    public partial class NKSLKContext : DbContext
    {
        public NKSLKContext()
        {
        }

        public NKSLKContext(DbContextOptions<NKSLKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<DanhMucKhoanChiTiet> DanhMucKhoanChiTiets { get; set; }
        public virtual DbSet<NgayCong> NgayCongs { get; set; }
        public virtual DbSet<NgayCongLamThem> NgayCongLamThems { get; set; }
        public virtual DbSet<NhanCong> NhanCongs { get; set; }
        public virtual DbSet<Nkslk> Nkslks { get; set; }
        public virtual DbSet<NkslkChiTiet> NkslkChiTiets { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=NKSLK;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CongViec>(entity =>
            {
                entity.HasKey(e => e.MaCongViec)
                    .HasName("PK__CongViec__CDBE9810E106F6C4");

                entity.Property(e => e.DinhMucKhoan).HasDefaultValueSql("('0.0')");

                entity.Property(e => e.DinhMucLaoDong).HasDefaultValueSql("('0.0')");

                entity.Property(e => e.DonGia).HasDefaultValueSql("('0.0')");

                entity.Property(e => e.DonViKhoan).HasDefaultValueSql("(N'tấn')");

                entity.Property(e => e.HeSoKhoan).HasDefaultValueSql("('0.0')");
            });

            modelBuilder.Entity<DanhMucKhoanChiTiet>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet)
                    .HasName("PK__DanhMucK__9996488899F4ABBC");

                entity.Property(e => e.SoLoSanPham).IsUnicode(false);

                entity.HasOne(d => d.MaCongViecNavigation)
                    .WithMany(p => p.DanhMucKhoanChiTiets)
                    .HasForeignKey(d => d.MaCongViec)
                    .HasConstraintName("fk_maCongViec");

                entity.HasOne(d => d.MaNkslkNavigation)
                    .WithMany(p => p.DanhMucKhoanChiTiets)
                    .HasForeignKey(d => d.MaNkslk)
                    .HasConstraintName("fk_maNKSLK_2");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.DanhMucKhoanChiTiets)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("fk_maSanPham");
            });

            modelBuilder.Entity<NgayCong>(entity =>
            {
                entity.ToView("NgayCong");
            });

            modelBuilder.Entity<NgayCongLamThem>(entity =>
            {
                entity.ToView("NgayCongLamThem");
            });

            modelBuilder.Entity<NhanCong>(entity =>
            {
                entity.HasKey(e => e.MaNhanCong)
                    .HasName("PK__NhanCong__E52107D3CE61EAB4");

                entity.Property(e => e.ChucVu).HasDefaultValueSql("(N'Nhân viên')");

                entity.Property(e => e.GioiTinh).HasDefaultValueSql("((0))");

                entity.Property(e => e.NgaySinh).HasDefaultValueSql("('2000-01-01')");

                entity.Property(e => e.PhongBan).HasDefaultValueSql("(N'Sản xuất')");
            });

            modelBuilder.Entity<Nkslk>(entity =>
            {
                entity.HasKey(e => e.MaNkslk)
                    .HasName("PK__NKSLK__7F440A39FF578588");

                entity.Property(e => e.Ngay).HasDefaultValueSql("('2000-01-01')");
            });

            modelBuilder.Entity<NkslkChiTiet>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet)
                    .HasName("PK__NKSLK_Ch__99964888B5B2EBA2");

                entity.Property(e => e.GioBatDau).HasDefaultValueSql("('06:00:00')");

                entity.Property(e => e.GioKetThuc).HasDefaultValueSql("('14:00:00')");

                entity.HasOne(d => d.MaNhanCongNavigation)
                    .WithMany(p => p.NkslkChiTiets)
                    .HasForeignKey(d => d.MaNhanCong)
                    .HasConstraintName("fk_maNhanCong");

                entity.HasOne(d => d.MaNkslkNavigation)
                    .WithMany(p => p.NkslkChiTiets)
                    .HasForeignKey(d => d.MaNkslk)
                    .HasConstraintName("fk_maNKSLK");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__5B439C43252CC9C0");

                entity.Property(e => e.NgayDangKy).HasDefaultValueSql("('2000-01-01')");

                entity.Property(e => e.NgaySanXuat).HasDefaultValueSql("('2000-01-01')");

                entity.Property(e => e.SoDangKy).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
