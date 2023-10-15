using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionFrancaApi.Domain.Entities.GestionFrancaEntities;

namespace GestionFrancaApi.DataAccess.Context
{
    public partial class GestionFrancaContext : DbContext
    {
        public GestionFrancaContext()
        {
        }

        public GestionFrancaContext(DbContextOptions<GestionFrancaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchOffice> BranchOffice { get; set; } = null!;
        public virtual DbSet<Items> Items { get; set; } = null!;
        public virtual DbSet<Technician> Technician { get; set; } = null!;
        public virtual DbSet<TechnicianItem> TechnicianItem { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.HasKey(e => e.IdBranchOffice)
                    .HasName("PK__BranchOf__FDD0E1938943076A");

                entity.Property(e => e.IdBranchOffice).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.IdItem)
                    .HasName("PK__Items__51E842621609168F");

                entity.Property(e => e.IdItem).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameItem)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.HasKey(e => e.IdTechnician)
                    .HasName("PK__Technici__0D1674ECF89DE629");

                entity.Property(e => e.IdTechnician).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<TechnicianItem>(entity =>
            {
                entity.HasKey(e => e.IdTechnicianItem)
                    .HasName("PK__Technici__FBDFD3C475B97655");

                entity.Property(e => e.IdTechnicianItem).ValueGeneratedNever();

                entity.HasOne(d => d.IdBranchOfficeNavigation)
                    .WithMany(p => p.TechnicianItem)
                    .HasForeignKey(d => d.IdBranchOffice)
                    .HasConstraintName("FK__Technicia__IdBra__37A5467C");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.TechnicianItem)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK__Technicia__IdIte__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
