using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUDWithAjax.EF;

public partial class SimpleCrudwithAjaxContext : DbContext
{
    public SimpleCrudwithAjaxContext()
    {
    }

    public SimpleCrudwithAjaxContext(DbContextOptions<SimpleCrudwithAjaxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07F4B0A28A");

            entity.ToTable("Product");

            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
