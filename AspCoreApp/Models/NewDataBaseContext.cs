using System;
using Microsoft.EntityFrameworkCore;

namespace AspCoreApp.Models
{
    public partial class NewDataBaseContext : DbContext
    {
        public NewDataBaseContext()
        {
        }

        public NewDataBaseContext(DbContextOptions<NewDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_COURSES_1");

                entity.ToTable("COURSES");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK_GROUPS_1");

                entity.ToTable("GROUPS");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_GROUPS_COURSES");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_STUDENTS_1");

                entity.ToTable("STUDENTS");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_STUDENTS_GROUPS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
