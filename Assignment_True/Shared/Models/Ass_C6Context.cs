using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment_True.Shared.Models
{
    public partial class Ass_C6Context : IdentityDbContext<IdentityUser>
    {
        public Ass_C6Context()
        {
        }

        public Ass_C6Context(DbContextOptions<Ass_C6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Diem> Diems { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<Nganh> Nganhs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<Truong> Truongs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Ass_C6;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaMonHoc });

                entity.ToTable("Diem");

                entity.Property(e => e.MaSv).HasColumnName("MaSV");

                entity.HasOne(d => d.MaMonHocNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaMonHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_MonHoc");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diem_SinhVien");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop);

                entity.ToTable("Lop");

                entity.Property(e => e.MaLop).ValueGeneratedNever();

                entity.Property(e => e.TenLop).HasMaxLength(50);

                entity.HasOne(d => d.MaTruongNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.MaTruong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lop_Truong");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMonHoc);

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMonHoc).ValueGeneratedNever();

                entity.Property(e => e.TenMonHoc).HasMaxLength(100);

                entity.HasOne(d => d.MaNganhNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaNganh)
                    .HasConstraintName("FK_MonHoc_Nganh");

                entity.HasOne(d => d.MaTruongNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.MaTruong)
                    .HasConstraintName("FK_MonHoc_Truong");
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.MaNganh);

                entity.ToTable("Nganh");

                entity.Property(e => e.MaNganh).ValueGeneratedNever();

                entity.Property(e => e.TenNganh).HasMaxLength(100);

                entity.HasOne(d => d.MaTruongNavigation)
                    .WithMany(p => p.Nganhs)
                    .HasForeignKey(d => d.MaTruong)
                    .HasConstraintName("FK_Nganh_Truong");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv);

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSV");

                entity.Property(e => e.Anh).IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.TenSv)
                    .HasMaxLength(100)
                    .HasColumnName("TenSV");

                entity.HasOne(d => d.MaLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaLop)
                    .HasConstraintName("FK_SinhVien_Lop");

                entity.HasOne(d => d.MaNganhNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaNganh)
                    .HasConstraintName("FK_SinhVien_Nganh");

                entity.HasOne(d => d.MaTruongNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaTruong)
                    .HasConstraintName("FK_SinhVien_Truong");
            });

            modelBuilder.Entity<Truong>(entity =>
            {
                entity.HasKey(e => e.MaTruong);

                entity.ToTable("Truong");

                entity.Property(e => e.MaTruong).ValueGeneratedNever();

                entity.Property(e => e.TenTruong).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
