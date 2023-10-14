using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HMS_Web_APIs.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HmsChatMessagesTable> HmsChatMessagesTables { get; set; } = null!;
        public virtual DbSet<HmsDoctorsTable> HmsDoctorsTables { get; set; } = null!;
        public virtual DbSet<HmsLoginTable> HmsLoginTables { get; set; } = null!;
        public virtual DbSet<HmsPatientsTable> HmsPatientsTables { get; set; } = null!;
        public virtual DbSet<HmsProviderAvailabilityTable> HmsProviderAvailabilityTables { get; set; } = null!;
        public virtual DbSet<HmsRolesTable> HmsRolesTables { get; set; } = null!;
        public virtual DbSet<HmsUserRoleMappingTable> HmsUserRoleMappingTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HmsChatMessagesTable>(entity =>
            {
                entity.ToTable("HmsChatMessagesTable");

                entity.Property(e => e.Timestamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<HmsDoctorsTable>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__HmsDocto__2DC00EBF6E8E825B");

                entity.ToTable("HmsDoctorsTable");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DoctorDob)
                    .HasColumnType("date")
                    .HasColumnName("DoctorDOB");

                entity.Property(e => e.DoctorEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<HmsLoginTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__HmsLogin__1788CC4CC59EABB0");

                entity.ToTable("HmsLoginTable");

                entity.HasIndex(e => e.UserEmail, "UQ__HmsLogin__08638DF80B507942")
                    .IsUnique();

                entity.HasIndex(e => e.UserPhone, "UQ__HmsLogin__F2577C47AA462A13")
                    .IsUnique();

                entity.Property(e => e.DoctorIdInDoctorTable).HasColumnName("DoctorId_In_DoctorTable");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.PatientIdInPatientTable).HasColumnName("PatientId_In_PatientTable");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HmsPatientsTable>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__HmsPatie__970EC36641F00C7A");

                entity.ToTable("HmsPatientsTable");

                entity.HasIndex(e => e.PatientPhone, "UQ__HmsPatie__94F42048FD0FC8B1")
                    .IsUnique();

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnType("date")
                    .HasColumnName("PatientDOB");

                entity.Property(e => e.PatientEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Symptoms)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<HmsProviderAvailabilityTable>(entity =>
            {
                entity.ToTable("HmsProviderAvailabilityTable");

                entity.Property(e => e.DateAvailable).HasColumnType("datetime");

                entity.Property(e => e.IsBooked).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BookedByNavigation)
                    .WithMany(p => p.HmsProviderAvailabilityTables)
                    .HasForeignKey(d => d.BookedBy)
                    .HasConstraintName("FK__HmsProvid__Booke__434443B6");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.HmsProviderAvailabilityTables)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__HmsProvid__Provi__443867EF");
            });

            modelBuilder.Entity<HmsRolesTable>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__HmsRoles__8AFACE1AAD0662DA");

                entity.ToTable("HmsRolesTable");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HmsUserRoleMappingTable>(entity =>
            {
                entity.HasKey(e => e.UserRoleMapId)
                    .HasName("PK__HmsUserR__D068457192F132F9");

                entity.ToTable("HmsUserRoleMappingTable");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.HmsUserRoleMappingTables)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__HmsUserRo__RoleI__509E3ED4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HmsUserRoleMappingTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__HmsUserRo__UserI__4FAA1A9B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
