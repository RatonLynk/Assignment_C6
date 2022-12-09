﻿// <auto-generated />
using System;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_True.Shared.Migrations
{
    [DbContext(typeof(Ass_C6Context))]
    [Migration("20220811125049_once")]
    partial class once
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment_True.Shared.Models.Diem", b =>
                {
                    b.Property<string>("MaSv")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("MaSV");

                    b.Property<string>("MaMonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DiemDocument")
                        .HasColumnType("float");

                    b.Property<double>("DiemPresentation")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("MaSv", "MaMonHoc");

                    b.HasIndex("MaMonHoc");

                    b.ToTable("Diem", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Lop", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaMonHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaMonHocNavigationMaMonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTruong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLop");

                    b.HasIndex("MaMonHocNavigationMaMonHoc");

                    b.HasIndex("MaTruong");

                    b.ToTable("Lop", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.MonHoc", b =>
                {
                    b.Property<string>("MaMonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTruong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenMonHoc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaMonHoc");

                    b.HasIndex("MaNganh");

                    b.HasIndex("MaTruong");

                    b.ToTable("MonHoc", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Nganh", b =>
                {
                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTruong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenNganh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNganh");

                    b.HasIndex("MaTruong");

                    b.ToTable("Nganh", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.SinhVien", b =>
                {
                    b.Property<string>("MaSv")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("MaSV");

                    b.Property<string>("Anh")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTruong")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenSv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TenSV");

                    b.HasKey("MaSv");

                    b.HasIndex("MaLop");

                    b.HasIndex("MaNganh");

                    b.HasIndex("MaTruong");

                    b.ToTable("SinhVien", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Truong", b =>
                {
                    b.Property<string>("MaTruong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TenTruong")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaTruong");

                    b.ToTable("Truong", (string)null);
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Diem", b =>
                {
                    b.HasOne("Assignment_True.Shared.Models.MonHoc", "MaMonHocNavigation")
                        .WithMany("Diems")
                        .HasForeignKey("MaMonHoc")
                        .IsRequired()
                        .HasConstraintName("FK_Diem_MonHoc");

                    b.HasOne("Assignment_True.Shared.Models.SinhVien", "MaSvNavigation")
                        .WithMany("Diems")
                        .HasForeignKey("MaSv")
                        .IsRequired()
                        .HasConstraintName("FK_Diem_SinhVien");

                    b.Navigation("MaMonHocNavigation");

                    b.Navigation("MaSvNavigation");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Lop", b =>
                {
                    b.HasOne("Assignment_True.Shared.Models.MonHoc", "MaMonHocNavigation")
                        .WithMany("Lops")
                        .HasForeignKey("MaMonHocNavigationMaMonHoc");

                    b.HasOne("Assignment_True.Shared.Models.Truong", "MaTruongNavigation")
                        .WithMany("Lops")
                        .HasForeignKey("MaTruong")
                        .HasConstraintName("FK_Lop_Truong");

                    b.Navigation("MaMonHocNavigation");

                    b.Navigation("MaTruongNavigation");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.MonHoc", b =>
                {
                    b.HasOne("Assignment_True.Shared.Models.Nganh", "MaNganhNavigation")
                        .WithMany("MonHocs")
                        .HasForeignKey("MaNganh")
                        .HasConstraintName("FK_MonHoc_Nganh");

                    b.HasOne("Assignment_True.Shared.Models.Truong", "MaTruongNavigation")
                        .WithMany("MonHocs")
                        .HasForeignKey("MaTruong")
                        .HasConstraintName("FK_MonHoc_Truong");

                    b.Navigation("MaNganhNavigation");

                    b.Navigation("MaTruongNavigation");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Nganh", b =>
                {
                    b.HasOne("Assignment_True.Shared.Models.Truong", "MaTruongNavigation")
                        .WithMany("Nganhs")
                        .HasForeignKey("MaTruong")
                        .HasConstraintName("FK_Nganh_Truong");

                    b.Navigation("MaTruongNavigation");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.SinhVien", b =>
                {
                    b.HasOne("Assignment_True.Shared.Models.Lop", "MaLopNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaLop")
                        .HasConstraintName("FK_SinhVien_Lop");

                    b.HasOne("Assignment_True.Shared.Models.Nganh", "MaNganhNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SinhVien_Nganh");

                    b.HasOne("Assignment_True.Shared.Models.Truong", "MaTruongNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaTruong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SinhVien_Truong");

                    b.Navigation("MaLopNavigation");

                    b.Navigation("MaNganhNavigation");

                    b.Navigation("MaTruongNavigation");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Lop", b =>
                {
                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.MonHoc", b =>
                {
                    b.Navigation("Diems");

                    b.Navigation("Lops");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Nganh", b =>
                {
                    b.Navigation("MonHocs");

                    b.Navigation("SinhViens");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.SinhVien", b =>
                {
                    b.Navigation("Diems");
                });

            modelBuilder.Entity("Assignment_True.Shared.Models.Truong", b =>
                {
                    b.Navigation("Lops");

                    b.Navigation("MonHocs");

                    b.Navigation("Nganhs");

                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
