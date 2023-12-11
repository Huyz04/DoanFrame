using System;
using System.Collections.Generic;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Models;

namespace MVC_DOAN.Data;

public partial class DoanContext : IdentityDbContext<Taikhoan>
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

    public virtual DbSet<Danhgia> Danhgias { get; set; }

    public virtual DbSet<Diachi> Diachis { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Phiship> Phiships { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
    }

}