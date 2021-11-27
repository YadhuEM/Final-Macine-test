using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravellingApplicationNew.Models
{
    public partial class FINAL_TRAVELContext : DbContext
    {
        public FINAL_TRAVELContext()
        {
        }

        public FINAL_TRAVELContext(DbContextOptions<FINAL_TRAVELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<ProjectTable> ProjectTable { get; set; }
        public virtual DbSet<RequestTable> RequestTable { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=YADHUKRISHNANEM\\SQLEXPRESS;Initial Catalog=FINAL_TRAVEL;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AFB3EC0DD4BA9858");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__EmployeeR__userI__29572725");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Login__CB9A1CFF34F7412C");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Login__roleId__267ABA7A");
            });

            modelBuilder.Entity<ProjectTable>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__ProjectT__11F14DA5C0F6DC71");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("projectName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestTable>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__RequestT__E3C5DE31170CBF8F");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.CauseTravel)
                    .HasColumnName("causeTravel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoDays)
                    .HasColumnName("noDays")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__RequestTa__empId__2E1BDC42");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__RequestTa__proje__2D27B809");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__CD98462A8D382D77");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
