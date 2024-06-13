using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GSBAPI.Models
{
    public partial class BtsBddContext : DbContext
    {
        public BtsBddContext()
        {
        }

        public BtsBddContext(DbContextOptions<BtsBddContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departement> Departements { get; set; } = null!;
        public virtual DbSet<Medecin> Medecins { get; set; } = null!;
        public virtual DbSet<Specialite> Specialites { get; set; } = null!;
        public virtual DbSet<Utillisateur> Utillisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=hugo;Initial Catalog=BtsBdd;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.IdDepartement)
                    .HasName("PK__departem__9E93B3EBF7E513DC");

                entity.ToTable("departement");

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDepartement");

                entity.Property(e => e.CodeRegion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NomDepartement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomRegionDepartement)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.HasKey(e => e.IdMedecin)
                    .HasName("PK__Medecin__180DFB72D967030B");

                entity.ToTable("Medecin");

                entity.Property(e => e.IdMedecin).HasColumnName("idMedecin");

                entity.Property(e => e.IdDepartement)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDepartement");

                entity.Property(e => e.IdSpecialite).HasColumnName("idSpecialite");

                entity.Property(e => e.NomMed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrenomMed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelMed)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartementNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdDepartement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__idDepar__3E52440B");

                entity.HasOne(d => d.IdSpecialiteNavigation)
                    .WithMany(p => p.Medecins)
                    .HasForeignKey(d => d.IdSpecialite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medecin__idSpeci__3D5E1FD2");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.IdSpecialite)
                    .HasName("PK__Speciali__1023B1568CF7D31E");

                entity.ToTable("Specialite");

                entity.Property(e => e.IdSpecialite).HasColumnName("idSpecialite");

                entity.Property(e => e.NomSpe)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utillisateur>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Utillisa__3717C982BF1BC17F");

                entity.ToTable("Utillisateur");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MdpUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mdpUser");

                entity.Property(e => e.NomUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrenomUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelUser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
