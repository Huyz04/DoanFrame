using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Models;

namespace MVC_DOAN.Data;

public partial class DoanContext : DbContext
{
    public DoanContext()
    {
    }

    public DoanContext(DbContextOptions<DoanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdon> Chitietdons { get; set; }

    public virtual DbSet<Ctgh> Ctghs { get; set; }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Diachi> Diachis { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Phiship> Phiships { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HUYZ04;Initial Catalog=DOAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdon>(entity =>
        {
            entity.HasKey(e => new { e.Madon, e.Masp }).HasName("PK__CHITIETD__3C460110B16E51DC");

            entity.ToTable("CHITIETDON");

            entity.Property(e => e.Madon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("madon");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masp");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MadonNavigation).WithMany(p => p.Chitietdons)
                .HasForeignKey(d => d.Madon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DH_CTD");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitietdons)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SP_CTD");
        });

        modelBuilder.Entity<Ctgh>(entity =>
        {
            entity.HasKey(e => new { e.Matk, e.Masp }).HasName("PK__CTGH__4D83697130C5FD7B");

            entity.ToTable("CTGH");

            entity.Property(e => e.Matk)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matk");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masp");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Ctghs)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SP_GH");

            entity.HasOne(d => d.MatkNavigation).WithMany(p => p.Ctghs)
                .HasForeignKey(d => d.Matk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TK_GH");
        });

        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity.HasKey(e => e.Madg).HasName("PK__DANHGIA__7A21E026E8F4641C");

            entity.ToTable("DANHGIA");

            entity.Property(e => e.Madg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("madg");
            entity.Property(e => e.Danhgiaa)
                .HasColumnType("text")
                .HasColumnName("danhgiaa");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masp");
            entity.Property(e => e.Matk)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matk");
            entity.Property(e => e.Rate).HasColumnName("rate");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK_SP_DG");

            entity.HasOne(d => d.MatkNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Matk)
                .HasConstraintName("FK_TK_DG");
        });

        modelBuilder.Entity<Diachi>(entity =>
        {
            entity.HasKey(e => e.Madc).HasName("PK__DIACHI__7A21E05ACDDAFB12");

            entity.ToTable("DIACHI");

            entity.Property(e => e.Madc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("madc");
            entity.Property(e => e.Diachichitiet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("diachichitiet");
            entity.Property(e => e.Hotennguoinhan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hotennguoinhan");
            entity.Property(e => e.Huyen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("huyen");
            entity.Property(e => e.Matk)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matk");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.Tinh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tinh");
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Madon).HasName("PK__DONHANG__0BE41677DB87ED07");

            entity.ToTable("DONHANG");

            entity.Property(e => e.Madon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("madon");
            entity.Property(e => e.Madc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("madc");
            entity.Property(e => e.Ngaygiao)
                .HasColumnType("date")
                .HasColumnName("ngaygiao");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("date")
                .HasColumnName("ngaytao");
            entity.Property(e => e.Phuongthucthanhtoan)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phuongthucthanhtoan");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            entity.Property(e => e.Trangthaidonhang)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("trangthaidonhang");
            entity.Property(e => e.Trangthaithanhtoan)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("trangthaithanhtoan");

            entity.HasOne(d => d.MadcNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.Madc)
                .HasConstraintName("FK_DH_DC");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.Malsp).HasName("PK__LOAISANP__15F47678578B3695");

            entity.ToTable("LOAISANPHAM");

            entity.Property(e => e.Malsp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("malsp");
            entity.Property(e => e.Tenlsp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tenlsp");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tinhtrang");
        });

        modelBuilder.Entity<Phiship>(entity =>
        {
            entity.HasKey(e => e.Maphi).HasName("PK__PHISHIP__0AFFEDDB0F87A23F");

            entity.ToTable("PHISHIP");

            entity.Property(e => e.Maphi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("maphi");
            entity.Property(e => e.Phi).HasColumnName("phi");
            entity.Property(e => e.Quan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("quan");
            entity.Property(e => e.Thoigian).HasColumnName("thoigian");
            entity.Property(e => e.Tinh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tinh");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK__SANPHAM__7A217672565A9A74");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masp");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Malsp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("malsp");
            entity.Property(e => e.Soluongdaban).HasColumnName("soluongdaban");
            entity.Property(e => e.Soluongtonkho).HasColumnName("soluongtonkho");
            entity.Property(e => e.Tensp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tensp");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tinhtrang");

            entity.HasOne(d => d.MalspNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Malsp)
                .HasConstraintName("FK_SP_LSP");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Matk).HasName("PK__TAIKHOAN__7A217E16F62E120F");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Matk)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matk");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Nickname)
                .HasMaxLength(100)
                .HasColumnName("nickname");
            entity.Property(e => e.Phanloai)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phanloai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
