﻿using System;
using Fait.DAL.NotMapped;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fait.DAL
{
    public partial class FAITContext : DbContext
    {
        public FAITContext()
        {
        }

        public FAITContext(DbContextOptions<FAITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentNameWithId> StudentNameWithIds { get; set; }
        public virtual DbSet<GroupNameWithId> GroupNameWithIds { get; set; }
        public virtual DbSet<Amend> Amends { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<ExperienceCompetition> ExperienceCompetitions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupPrefix> GroupPrefixes { get; set; }
        public virtual DbSet<GroupStudent> GroupStudents { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentState> StudentStates { get; set; }
        public virtual DbSet<StudentTransferHistory> StudentTransferHistories { get; set; }
        public virtual DbSet<StudentsInfo> StudentsInfos { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectSemester> SubjectSemesters { get; set; }
        public virtual DbSet<YearPlan> YearPlans { get; set; }
        public virtual DbSet<YearPlanGroup> YearPlanGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentNameWithId>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("id");

                entity.Property(e => e.StudentName).HasColumnName("full_name");

                entity.HasNoKey();
            });

            modelBuilder.Entity<GroupNameWithId>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("id");

                entity.Property(e => e.GroupName).HasColumnName("full_name");

                entity.HasNoKey();
            });

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Amend>(entity =>
            {
                entity.ToTable("Amend");

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.ToTable("Degree");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExperienceCompetition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(d => d.GroupPrefix)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupPrefixId)
                    .HasConstraintName("FK__Groups__GroupPre__47DBAE45");
            });

            modelBuilder.Entity<GroupPrefix>(entity =>
            {
                entity.ToTable("GroupPrefix");

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<GroupStudent>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.StudentId })
                    .HasName("PK__GroupStu__97B6A1D3920BD7FE");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Group__48CFD27E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Stude__49C3F6B7");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("marital_statuses");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MaritalStatusName)
                    .HasMaxLength(40)
                    .HasColumnName("marital_status_name");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ModifiedOn).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.SubjectMark).HasColumnName("subject_mark");

                entity.Property(e => e.TaskMark).HasColumnName("task_mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__marks__student_i__4AB81AF0");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__marks__subject_i__4BAC3F29");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("last_name");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("patronymic");

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.StudentStateId)
                    .HasColumnName("student_state_id")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK__students__specia__4CA06362");

                entity.HasOne(d => d.StudentState)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students__studen__4D94879B");
            });

            modelBuilder.Entity<StudentState>(entity =>
            {
                entity.ToTable("StudentState");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StudentTransferHistory>(entity =>
            {
                entity.ToTable("StudentTransferHistory");

                entity.Property(e => e.OperationDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.StudentTransferHistories)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTr__State__5441852A");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTransferHistories)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTr__Stude__534D60F1");
            });

            modelBuilder.Entity<StudentsInfo>(entity =>
            {
                entity.ToTable("students_info");

                entity.HasIndex(e => e.RegistrOrPassportNumber, "UQ__tmp_ms_x__C8F12B6998978A7B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmendId).HasDefaultValueSql("((1))");

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("birth_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Citizenship)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CompetitionConditions)
                    .HasMaxLength(30)
                    .HasColumnName("competition_conditions");

                entity.Property(e => e.EmploymentAuthority)
                    .HasMaxLength(30)
                    .HasColumnName("employment_authority");

                entity.Property(e => e.EmploymentGivenDate)
                    .HasColumnType("date")
                    .HasColumnName("employment_given_date");

                entity.Property(e => e.EmploymentNumber).HasColumnName("employment_number");

                entity.Property(e => e.Exemption)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("exemption");

                entity.Property(e => e.ExpirienceCompetitionId)
                    .HasColumnName("expirience_competition_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GraduatedSchoolName).HasMaxLength(200);

                entity.Property(e => e.GraduatedYear);

                entity.Property(e => e.MaritalStatusId)
                    .HasColumnName("marital_status_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OutOfCompetitionInfo)
                    .HasMaxLength(30)
                    .HasColumnName("out_of_competition_info");

                entity.Property(e => e.RegistrOrPassportNumber)
                    .HasMaxLength(50)
                    .HasColumnName("registr_or_passport_number");

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("registration");

                entity.Property(e => e.TransferDirection)
                    .HasMaxLength(200)
                    .HasColumnName("transfer_direction");

                entity.Property(e => e.TransferFrom)
                    .HasMaxLength(200)
                    .HasColumnName("transfer_from");

                entity.HasOne(d => d.Amend)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.AmendId)
                    .HasConstraintName("FK__students___Amend__7A672E12");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.DegreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students___Degre__7D439ABD");

                entity.HasOne(d => d.ExpirienceCompetition)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.ExpirienceCompetitionId)
                    .HasConstraintName("FK__students___expir__7B5B524B");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK__students___marit__7C4F7684");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Subject__PlanId__5535A963");
            });

            modelBuilder.Entity<SubjectSemester>(entity =>
            {
                entity.ToTable("SubjectSemester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectSemesters)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectSe__Subje__5629CD9C");
            });

            modelBuilder.Entity<YearPlan>(entity =>
            {
                entity.ToTable("YearPlan");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<YearPlanGroup>(entity =>
            {
                entity.HasKey(e => new { e.YearPlanId, e.GroupId })
                    .HasName("PK__YearPlan__E408884872A9FFF1");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__Group__5812160E");

                entity.HasOne(d => d.YearPlan)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.YearPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__YearP__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
