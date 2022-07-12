using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
        {
        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignproject> Assignprojects { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Proj> Projs { get; set; }
        public virtual DbSet<Salarycategory> Salarycategories { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=sbd25584;Password=sbd25584;Host=150.254.210.3;Port=6432;Database=sbd_2021_22_l_db;SearchPath=sbd25584;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignproject>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectName })
                    .HasName("assignprojects_pkey");

                entity.ToTable("assignprojects", "sbd25584");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("project_name");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("date")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("date")
                    .HasColumnName("date_to");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("role");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assignprojects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assignprojects_employee_id_fkey");

                entity.HasOne(d => d.ProjectNameNavigation)
                    .WithMany(p => p.Assignprojects)
                    .HasForeignKey(d => d.ProjectName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assignprojects_project_name_fkey");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.DepartmentName)
                    .HasName("depts_pkey");

                entity.ToTable("depts", "sbd25584");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasColumnName("department_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Depts)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("depts_location_id_fkey");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("emps_pkey");

                entity.ToTable("emps", "sbd25584");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("category_name");

                entity.Property(e => e.ContractEndDate)
                    .HasColumnType("date")
                    .HasColumnName("contract_end_date");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("department_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Salary)
                    .HasPrecision(7, 2)
                    .HasColumnName("salary");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("team_name");

                entity.HasOne(d => d.CategoryNameNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.CategoryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emps_category_name_fkey");

                entity.HasOne(d => d.DepartmentNameNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.DepartmentName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emps_department_name_fkey");

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.TeamName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emps_team_name_fkey");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations", "sbd25584");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("location_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.Property(e => e.StreetAndNumber)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("street_and_number");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentName, e.TeamName, e.EmployeeId })
                    .HasName("managers_pkey");

                entity.ToTable("managers", "sbd25584");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasColumnName("department_name");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .HasColumnName("team_name");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("date")
                    .HasColumnName("date_from");

                entity.Property(e => e.DateTo)
                    .HasColumnType("date")
                    .HasColumnName("date_to");

                entity.HasOne(d => d.DepartmentNameNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.DepartmentName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("managers_department_name_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("managers_employee_id_fkey");

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.TeamName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("managers_team_name_fkey");
            });

            modelBuilder.Entity<Proj>(entity =>
            {
                entity.HasKey(e => e.ProjectName)
                    .HasName("projs_pkey");

                entity.ToTable("projs", "sbd25584");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("project_name");

                entity.Property(e => e.DeadlineDate)
                    .HasColumnType("date")
                    .HasColumnName("deadline_date");

                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Salarycategory>(entity =>
            {
                entity.HasKey(e => e.CategoryName)
                    .HasName("salarycategories_pkey");

                entity.ToTable("salarycategories", "sbd25584");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");

                entity.Property(e => e.MaxSalary)
                    .HasPrecision(7, 2)
                    .HasColumnName("max_salary");

                entity.Property(e => e.MinSalary)
                    .HasPrecision(7, 2)
                    .HasColumnName("min_salary");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamName)
                    .HasName("teams_pkey");

                entity.ToTable("teams", "sbd25584");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .HasColumnName("team_name");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("department_name");

                entity.HasOne(d => d.DepartmentNameNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.DepartmentName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teams_department_name_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
