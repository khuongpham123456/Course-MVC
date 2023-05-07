using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VNR_InternShip.Entities
{
    public partial class VNR_InternShipContext : DbContext
    {
        public VNR_InternShipContext()
        {
        }

        public VNR_InternShipContext(DbContextOptions<VNR_InternShipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=VNR_InternShip;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.ToTable("KhoaHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenKhoaHoc).HasMaxLength(30);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MonHoc");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KhoaHocId).HasColumnName("KhoaHocID");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenMonHoc).HasMaxLength(100);

                entity.HasOne(d => d.KhoaHoc)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.KhoaHocId)
                    .HasConstraintName("FK_dbo.BaiHat_dbo.TheLoai_TheLoaiID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
