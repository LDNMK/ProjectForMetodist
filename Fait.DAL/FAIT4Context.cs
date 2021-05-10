using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fait.DAL
{
    public partial class FAIT4Context : DbContext
    {
        public FAIT4Context()
        {
        }

        public FAIT4Context(DbContextOptions<FAIT4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualGroup> ActualGroups { get; set; }
        public virtual DbSet<Ammende> Ammendes { get; set; }
        public virtual DbSet<ExpirienceCompetitione> ExpirienceCompetitiones { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupName> GroupNames { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentState> StudentStates { get; set; }
        public virtual DbSet<StudentsInfo> StudentsInfos { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TransferOrder> TransferOrders { get; set; }
        public virtual DbSet<YearPlan> YearPlans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=FAIT4;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ActualGroup>(entity =>
            {
                entity.ToTable("actual_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__actual_gr__group__45F365D3");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__actual_gr__stude__46E78A0C");
            });

            modelBuilder.Entity<Ammende>(entity =>
            {
                entity.ToTable("ammendes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmmendType)
                    .HasMaxLength(40)
                    .HasColumnName("ammend_type");
            });

            modelBuilder.Entity<ExpirienceCompetitione>(entity =>
            {
                entity.ToTable("expirience_competitiones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExpirienceName)
                    .HasMaxLength(40)
                    .HasColumnName("expirience_name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actual).HasColumnName("actual");

                entity.Property(e => e.GroupNameId).HasColumnName("group_name_id");

                entity.Property(e => e.GroupNumber).HasColumnName("group_number");

                entity.Property(e => e.GroupYear).HasColumnName("group_year");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.HasOne(d => d.GroupName)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupNameId)
                    .HasConstraintName("FK__groups__group_na__4316F928");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__groups__plan_id__4222D4EF");
            });

            modelBuilder.Entity<GroupName>(entity =>
            {
                entity.ToTable("group_names");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameOfGroup)
                    .HasMaxLength(40)
                    .HasColumnName("name_of_group");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("marital_statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaritalStatusName)
                    .HasMaxLength(40)
                    .HasColumnName("marital_status_name");
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
                    .HasConstraintName("FK__marks__student_i__4E88ABD4");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__marks__subject_i__4F7CD00D");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Kode).HasColumnName("kode");

                entity.Property(e => e.SpecialityName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("speciality_name");

                entity.Property(e => e.SpecializationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("specialization_name");
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

                entity.Property(e => e.StudentState)
                    .HasColumnName("student_state")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK__students__specia__286302EC");

                entity.HasOne(d => d.StudentStateNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students__studen__29572725");
            });

            modelBuilder.Entity<StudentState>(entity =>
            {
                entity.ToTable("student_states");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StudentStateName)
                    .HasMaxLength(30)
                    .HasColumnName("student_state_name");
            });

            modelBuilder.Entity<StudentsInfo>(entity =>
            {
                entity.ToTable("students_info");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AmmendsId)
                    .HasColumnName("ammends_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("birth_place");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

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

                entity.Property(e => e.Immenseness)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("immenseness");

                entity.Property(e => e.MaritalStatusId)
                    .HasColumnName("marital_status_id")
                    .HasDefaultValueSql("((1))");

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
                    .HasMaxLength(30)
                    .HasColumnName("transfer_direction");

                entity.Property(e => e.TransferFrom)
                    .HasMaxLength(30)
                    .HasColumnName("transfer_from");

                entity.HasOne(d => d.Ammends)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.AmmendsId)
                    .HasConstraintName("FK__students___ammen__38996AB5");

                entity.HasOne(d => d.ExpirienceCompetition)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.ExpirienceCompetitionId)
                    .HasConstraintName("FK__students___expir__36B12243");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.StudentsInfo)
                    .HasForeignKey<StudentsInfo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students___regis__3A81B327");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK__students___marit__34C8D9D1");
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
                    .HasConstraintName("FK__subjects__plan_i__49C3F6B7");
            });

            modelBuilder.Entity<TransferOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__transfer__46596229341D69C8");

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
                    .HasConstraintName("FK__transfer___stude__3D5E1FD2");
            });

            modelBuilder.Entity<YearPlan>(entity =>
            {
                entity.ToTable("year_plans");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actual).HasColumnName("actual");

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
