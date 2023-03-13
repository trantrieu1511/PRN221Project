using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Data;

public partial class Prn221ProjectQlnsContext : DbContext
{
    public Prn221ProjectQlnsContext()
    {
    }

    public Prn221ProjectQlnsContext(DbContextOptions<Prn221ProjectQlnsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<MyCompany> MyCompanies { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    //ReConfig OnConfiguring method.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__account__AEBB701FDEB19642");

            entity.ToTable("account");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("profile_id");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ismanager).HasColumnName("ismanager");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Profile).WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__account__profile__30F848ED");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__attendan__7B267220EE736B29");

            entity.ToTable("attendance");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.Date)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Note)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.ProductionTime)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("production_time");
            entity.Property(e => e.TimeIn)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("time_out");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__client__BF21A424FD170445");

            entity.ToTable("client");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");

            entity.HasOne(d => d.Company).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__client__company___47DBAE45");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company__3E267235BFF47454");

            entity.ToTable("company");

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("company_name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C22324223D6621BE");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__job__6E32B6A56718781C");

            entity.ToTable("job");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.MaxSalary)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("max_salary");
            entity.Property(e => e.MinSalary)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("min_salary");
        });

        modelBuilder.Entity<MyCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__myCompan__3E26723572FFA3A0");

            entity.ToTable("myCompany");

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyAddress)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company_address");
            entity.Property(e => e.CompanyCity)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("company_city");
            entity.Property(e => e.CompanyCountry)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("company_country");
            entity.Property(e => e.CompanyEmail)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("company_email");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyPnumber).HasColumnName("company_pnumber");
            entity.Property(e => e.CompanyProvince)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("company_province");
            entity.Property(e => e.Fax).HasColumnName("fax");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.WebsiteUrl)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website_url");

            entity.HasOne(d => d.Profile).WithMany(p => p.MyCompanies)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__myCompany__profi__4316F928");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__profile__AEBB701FBEC30EAE");

            entity.ToTable("profile");

            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.AnnualLeave)
                .HasDefaultValueSql("((12))")
                .HasColumnName("annual_leave");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hire_date");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.ReportTo).HasColumnName("report_to");

            entity.HasOne(d => d.Department).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__profile__departm__2C3393D0");

            entity.HasOne(d => d.Job).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__profile__job_id__2B3F6F97");

            entity.HasOne(d => d.ReportToNavigation).WithMany(p => p.InverseReportToNavigation)
                .HasForeignKey(d => d.ReportTo)
                .HasConstraintName("FK__profile__report___2D27B809");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Title).HasName("PK__project__E52A1BB2AC88799F");

            entity.ToTable("project");

            entity.Property(e => e.Title)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Period)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("period");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("rate");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__project__client___5070F446");

            entity.HasOne(d => d.Manager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__project__manager__5165187F");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__salary__AEBB701FD37F3836");

            entity.ToTable("salary");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("profile_id");
            entity.Property(e => e.Allowance)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("allowance");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("basic_salary");
            entity.Property(e => e.Conveyance)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("conveyance");
            entity.Property(e => e.CreateDate)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("create_date");
            entity.Property(e => e.Da)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("DA");
            entity.Property(e => e.Esi)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("ESI");
            entity.Property(e => e.Hra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("HRA");
            entity.Property(e => e.Leave)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("leave");
            entity.Property(e => e.Loan)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("loan");
            entity.Property(e => e.MedicalAllowance)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("medical_allowance");
            entity.Property(e => e.Pf)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("PF");
            entity.Property(e => e.ProfessionalTax)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("professional_tax");
            entity.Property(e => e.Tds)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("TDS");

            entity.HasOne(d => d.Profile).WithOne(p => p.Salary)
                .HasForeignKey<Salary>(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__salary__create_d__3E52440B");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("schedule");

            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("shift_name");

            entity.HasOne(d => d.Profile).WithMany()
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK__schedule__profil__4D94879B");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__shift__72E12F1ADBF53171");

            entity.ToTable("shift");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.EndTime)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("start_time");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task__3213E83FEE69D8F3");

            entity.ToTable("task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assigned).HasColumnName("assigned");
            entity.Property(e => e.Deadline)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deadline");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Project)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("project");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.AssignedNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Assigned)
                .HasConstraintName("FK__task__assigned__5441852A");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Project)
                .HasConstraintName("FK__task__project__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
