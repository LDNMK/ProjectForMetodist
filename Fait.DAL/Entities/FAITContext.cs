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
        public virtual DbSet<Amend> Amends { get; set; }
        public virtual DbSet<ControlType> ControlTypes { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<ExperienceCompetition> ExperienceCompetitions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupPrefix> GroupPrefixes { get; set; }
        public virtual DbSet<GroupStudent> GroupStudents { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentInfo> StudentInfos { get; set; }
        public virtual DbSet<StudentState> StudentStates { get; set; }
        public virtual DbSet<StudentTransferHistory> StudentTransferHistories { get; set; }
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
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Amend>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ControlType>(entity =>
            {
                entity.ToTable("ControlType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.ToTable("Degree");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExperienceCompetition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(d => d.GroupPrefix)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupPrefixId)
                    .HasConstraintName("FK__Groups__GroupPre__4CA06362");
            });

            modelBuilder.Entity<GroupPrefix>(entity =>
            {
                entity.ToTable("GroupPrefix");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<GroupStudent>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.StudentId })
                    .HasName("PK__GroupStu__97B6A1D39D6B5A1E");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Group__4D94879B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupStud__Stude__4E88ABD4");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("MaritalStatus");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("Mark");

                entity.Property(e => e.ModifiedOn).HasColumnType("date");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mark__StudentId__4F7CD00D");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mark__SubjectId__5070F446");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
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
                entity.ToTable("Student");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.StudentStateId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK__Student__Special__5165187F");

                entity.HasOne(d => d.StudentState)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StudentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__Student__52593CB8");
            });

            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.ToTable("StudentInfo");

                entity.HasIndex(e => e.RegistrOrPassportNumber, "UQ__StudentI__C4B5110300DB3C45")
                    .IsUnique();

                entity.Property(e => e.AmendsId).HasDefaultValueSql("((1))");

                entity.Property(e => e.BirthPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Citizenship)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CompetitionConditions).HasMaxLength(100);

                entity.Property(e => e.EmploymentAuthority).HasMaxLength(30);

                entity.Property(e => e.EmploymentGivenDate).HasColumnType("date");

                entity.Property(e => e.Exemption)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExperienceCompetitionId).HasDefaultValueSql("((1))");

                entity.Property(e => e.GraduatedSchoolName).HasMaxLength(170);

                entity.Property(e => e.MaritalStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderNumber).HasMaxLength(10);

                entity.Property(e => e.OutOfCompetitionInfo).HasMaxLength(100);

                entity.Property(e => e.RegistrOrPassportNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(170);

                entity.Property(e => e.TransferDirection).HasMaxLength(170);

                entity.Property(e => e.TransferFrom).HasMaxLength(170);

                entity.HasOne(d => d.Amends)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.AmendsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentIn__Amend__534D60F1");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.DegreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentIn__Degre__5629CD9C");

                entity.HasOne(d => d.ExperienceCompetition)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.ExperienceCompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentIn__Exper__5441852A");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.StudentInfos)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentIn__Marit__5535A963");
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
                    .HasConstraintName("FK__StudentTr__State__5812160E");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTransferHistories)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentTr__Stude__571DF1D5");
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
                    .HasConstraintName("FK__Subject__PlanId__59063A47");
            });

            modelBuilder.Entity<SubjectSemester>(entity =>
            {
                entity.ToTable("SubjectSemester");

                entity.HasOne(d => d.ControlType)
                    .WithMany(p => p.SubjectSemesters)
                    .HasForeignKey(d => d.ControlTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectSe__Contr__5AEE82B9");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SubjectSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectSe__Semes__5BE2A6F2");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectSemesters)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectSe__Subje__59FA5E80");
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
                    .HasName("PK__YearPlan__E4088848E1C1D790");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__Group__5DCAEF64");

                entity.HasOne(d => d.YearPlan)
                    .WithMany(p => p.YearPlanGroups)
                    .HasForeignKey(d => d.YearPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YearPlanG__YearP__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
