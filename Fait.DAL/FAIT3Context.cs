using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fait.DAL
{
    public partial class FAIT3Context : DbContext
    {
        public FAIT3Context()
        {
        }

        public FAIT3Context(DbContextOptions<FAIT3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualGroup> ActualGroups { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsInfo> StudentsInfos { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TransferOrder> TransferOrders { get; set; }
        public virtual DbSet<YearPlan> YearPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=FAIT3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ActualGroup>(entity =>
            {
                entity.ToTable("actual_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actual).HasColumnName("actual");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__actual_gr__group__49C3F6B7");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__actual_gr__stude__4AB81AF0");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupName).HasColumnName("group_name");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__groups__plan_id__46E78A0C");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.SubjectMark).HasColumnName("subject_mark");

                entity.Property(e => e.TaskMark).HasColumnName("task_mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__marks__student_i__52593CB8");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__marks__subject_i__534D60F1");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("direction");

                entity.Property(e => e.Kode).HasColumnName("kode");
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

                entity.Property(e => e.StudState).HasColumnName("stud_state");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK__students__specia__38996AB5");
            });

            modelBuilder.Entity<StudentsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("students_info");

                entity.HasIndex(e => e.Id, "UQ__students__3213E83E9A035A45")
                    .IsUnique();

                entity.Property(e => e.Ammends)
                    .HasColumnName("ammends")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("birth_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.Competition)
                    .HasColumnName("competition")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Direction)
                    .HasMaxLength(30)
                    .HasColumnName("direction");

                entity.Property(e => e.Exemption)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("exemption");

                entity.Property(e => e.FromIns)
                    .HasMaxLength(30)
                    .HasColumnName("from_ins");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Immenseness)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("immenseness");

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("marital_status")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.NoCompetititon)
                    .HasMaxLength(30)
                    .HasColumnName("no_competititon");

                entity.Property(e => e.Registartion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("registartion");

                entity.Property(e => e.Uniq)
                    .HasMaxLength(30)
                    .HasColumnName("uniq");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne()
                    .HasForeignKey<StudentsInfo>(d => d.Id)
                    .HasConstraintName("FK__students_inf__id__3C69FB99");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ects).HasColumnName("ects");

                entity.Property(e => e.Monitoring).HasColumnName("monitoring");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.SubHours).HasColumnName("sub_hours");

                entity.Property(e => e.SubName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("sub_name");

                entity.Property(e => e.Task).HasColumnName("task");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__subjects__plan_i__4D94879B");
            });

            modelBuilder.Entity<TransferOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__transfer__4659622909F76327");

                entity.ToTable("transfer_orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("content");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TransferOrders)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__transfer___stude__4222D4EF");
            });

            modelBuilder.Entity<YearPlan>(entity =>
            {
                entity.ToTable("year_plans");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("plan_name");

                entity.Property(e => e.PlanYear).HasColumnName("plan_year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
