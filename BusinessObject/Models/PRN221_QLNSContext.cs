﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class PRN221_QLNSContext : DbContext
    {
        public PRN221_QLNSContext()
        {
        }

        public PRN221_QLNSContext(DbContextOptions<PRN221_QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<FamilyInfo> FamilyInfos { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<MyCompany> MyCompanies { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<ProfileDetail> ProfileDetails { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = localhost; database = PRN221_QLNS; uid=sa; pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("account");

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Ismanager).HasColumnName("ismanager");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Profile)
                    .WithMany()
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__account__profile__300424B4");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.ShiftId)
                    .HasName("PK__attendan__7B26722087993CAF");

                entity.ToTable("attendance");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.Date)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Note)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.ProductionTime)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("production_time");

                entity.Property(e => e.TimeIn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("time_in");

                entity.Property(e => e.TimeOut)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("time_out");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clients__company__4CA06362");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("experience");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("end_date");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Profile)
                    .WithMany()
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__experienc__profi__4316F928");
            });

            modelBuilder.Entity<FamilyInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("familyInfo");

                entity.Property(e => e.Dob)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dob");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("relationship");

                entity.HasOne(d => d.Profile)
                    .WithMany()
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__familyInf__profi__412EB0B6");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobTitle)
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
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__myCompan__3E267235AC6506D1");

                entity.ToTable("myCompany");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_address");

                entity.Property(e => e.CompanyCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("company_city");

                entity.Property(e => e.CompanyCountry)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("company_country");

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_email");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyPnumber).HasColumnName("company_pnumber");

                entity.Property(e => e.CompanyProvince)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("company_province");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.WebsiteUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("website_url");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.MyCompanies)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__myCompany__profi__47DBAE45");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.AnnualLeave)
                    .HasColumnName("annual_leave")
                    .HasDefaultValueSql("((12))");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("hire_date");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.ReportTo).HasColumnName("report_to");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__profile__departm__2C3393D0");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__profile__job_id__2B3F6F97");

                entity.HasOne(d => d.ReportToNavigation)
                    .WithMany(p => p.InverseReportToNavigation)
                    .HasForeignKey(d => d.ReportTo)
                    .HasConstraintName("FK__profile__report___2D27B809");
            });

            modelBuilder.Entity<ProfileDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("profileDetail");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BankName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bank_name");

                entity.Property(e => e.BankNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bank_number");

                entity.Property(e => e.Children).HasColumnName("children");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Dob)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dob");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsMarried).HasColumnName("isMarried");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("religion");

                entity.HasOne(d => d.Profile)
                    .WithMany()
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__profileDe__profi__3F466844");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("PK__project__E52A1BB2EDBB8A3E");

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__project__client___5535A963");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__project__manager__5629CD9C");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.PayslipNumber)
                    .HasName("PK__salary__4BFC7065A14370EA");

                entity.ToTable("salary");

                entity.Property(e => e.PayslipNumber).HasColumnName("payslip_number");

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

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Tds)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("TDS");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__salary__create_d__3D5E1FD2");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("schedule");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("shift_name");

                entity.HasOne(d => d.Profile)
                    .WithMany()
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__schedule__profil__52593CB8");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__shift__72E12F1A7FB91B91");

                entity.ToTable("shift");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("end_time");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("start_time");
            });

            modelBuilder.Entity<Task>(entity =>
            {
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

                entity.HasOne(d => d.AssignedNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Assigned)
                    .HasConstraintName("FK__task__assigned__59063A47");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("FK__task__project__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}