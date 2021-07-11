using System;
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
        public virtual DbSet<ActualGroup> ActualGroups { get; set; }
        public virtual DbSet<Amend> Amends { get; set; }
        public virtual DbSet<ExperienceCompetition> ExperienceCompetitions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupPrefix> GroupPrefixes { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentState> StudentStates { get; set; }
        public virtual DbSet<StudentTransferOrder> StudentTransferOrders { get; set; }
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

            modelBuilder.Entity<ActualGroup>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.StudentId })
                    .HasName("PK__ActualGr__97B6A1D317C8B520");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActualGro__Group__46E78A0C");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ActualGroups)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActualGro__Stude__47DBAE45");
            });

            modelBuilder.Entity<Amend>(entity =>
            {
                entity.ToTable("Amend");

                entity.Property(e => e.Name).HasMaxLength(40);
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
                    .HasConstraintName("FK__Groups__GroupPre__48CFD27E");
            });

            modelBuilder.Entity<GroupPrefix>(entity =>
            {
                entity.ToTable("GroupPrefix");

                entity.Property(e => e.Name).HasMaxLength(40);
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

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.SubjectMark).HasColumnName("subject_mark");

                entity.Property(e => e.TaskMark).HasColumnName("task_mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__marks__student_i__49C3F6B7");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__marks__subject_i__4AB81AF0");
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
                    .HasConstraintName("FK__students__specia__4BAC3F29");

                entity.HasOne(d => d.StudentState)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students__studen__4CA06362");
            });

            modelBuilder.Entity<StudentState>(entity =>
            {
                entity.ToTable("student_states");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.StudentStateName)
                    .HasMaxLength(30)
                    .HasColumnName("student_state_name");
            });

            modelBuilder.Entity<StudentTransferOrder>(entity =>
            {
                entity.ToTable("StudentTransferOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.OperationDate).HasColumnType("date");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTransferOrders)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__StudentTr__Stude__5165187F");
            });

            modelBuilder.Entity<StudentsInfo>(entity =>
            {
                entity.ToTable("students_info");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AmendId).HasDefaultValueSql("((1))");

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

                entity.HasOne(d => d.Amend)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.AmendId)
                    .HasConstraintName("FK__students___Amend__4D94879B");

                entity.HasOne(d => d.ExpirienceCompetition)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.ExpirienceCompetitionId)
                    .HasConstraintName("FK__students___expir__4E88ABD4");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.StudentsInfo)
                    .HasForeignKey<StudentsInfo>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students_inf__id__4F7CD00D");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.StudentsInfos)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK__students___marit__5070F446");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Subject__PlanId__52593CB8");
            });

            modelBuilder.Entity<SubjectSemester>(entity =>
            {
                entity.ToTable("SubjectSemester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectSemesters)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectSe__Subje__534D60F1");
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
                    .HasName("PK__YearPlan__E4088848381CD83F");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__Group__5535A963");

                entity.HasOne(d => d.YearPlan)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.YearPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__YearP__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
