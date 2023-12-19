﻿// <auto-generated />
using System;
using MVC_DOAN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_DOAN.Migrations
{
    [DbContext(typeof(DoanContext))]
    partial class DoanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_DOAN.Models.Chitietdon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Dongia")
                        .HasColumnType("int");

                    b.Property<int?>("DonhangId")
                        .HasColumnType("int");

                    b.Property<int?>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Chitietdons");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Ctgh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Ctghs");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Danhgia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Danhgiaa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("SanphamId")
                        .HasColumnType("int");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SanphamId");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Danhgias");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Diachi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diachichitiet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotennguoinhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Diachis");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Donhang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DiachiId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Ngaygiao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Ngaytao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phuongthucthanhtoan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Tongtien")
                        .HasColumnType("int");

                    b.Property<string>("Trangthaidonhang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trangthaithanhtoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiachiId");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Donhangs");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Loaisanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tenlsp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tinhtrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Loaisanphams");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Phiship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Phi")
                        .HasColumnType("int");

                    b.Property<string>("Quan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Thoigian")
                        .HasColumnType("int");

                    b.Property<string>("Tinh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Phiships");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Sanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Dongia")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaisanphamId")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Soluongdaban")
                        .HasColumnType("int");

                    b.Property<int?>("Soluongtonkho")
                        .HasColumnType("int");

                    b.Property<string>("TaikhoanId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tensp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tinhtrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaisanphamId");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Sanphams");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Taikhoan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matkhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phanloai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MVC_DOAN.Models.Chitietdon", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Chitietdons")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Ctgh", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Ctghs")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Danhgia", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Sanpham", "Sanpham")
                        .WithMany()
                        .HasForeignKey("SanphamId");

                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Danhgias")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Sanpham");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Diachi", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Diachi")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Donhang", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Diachi", "Diachi")
                        .WithMany()
                        .HasForeignKey("DiachiId");

                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Donhangs")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Diachi");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Loaisanpham", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Loaisanphams")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Phiship", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Phiships")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("MVC_DOAN.Models.Sanpham", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Loaisanpham", "Loaisanpham")
                        .WithMany()
                        .HasForeignKey("LoaisanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_DOAN.Models.Taikhoan", "Taikhoan")
                        .WithMany("Sanphams")
                        .HasForeignKey("TaikhoanId");

                    b.Navigation("Loaisanpham");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_DOAN.Models.Taikhoan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MVC_DOAN.Models.Taikhoan", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_DOAN.Models.Taikhoan", b =>
                {
                    b.Navigation("Chitietdons");

                    b.Navigation("Ctghs");

                    b.Navigation("Danhgias");

                    b.Navigation("Diachi");

                    b.Navigation("Donhangs");

                    b.Navigation("Loaisanphams");

                    b.Navigation("Phiships");

                    b.Navigation("Sanphams");
                });
#pragma warning restore 612, 618
        }
    }
}
