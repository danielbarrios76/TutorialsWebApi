using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TutorialsWebApi.Models
{
    public partial class TutorialsDBContext : DbContext
    {
        public TutorialsDBContext()
        {
        }

        public TutorialsDBContext(DbContextOptions<TutorialsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassRoom> ClassRoom { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsClassRoom> StudentsClassRoom { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectsId).HasColumnName("SubjectsID");

                entity.Property(e => e.TeachersId).HasColumnName("TeachersID");

                entity.HasOne(d => d.Subjects)
                    .WithMany(p => p.ClassRoom)
                    .HasForeignKey(d => d.SubjectsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects_ClassRoom");

                entity.HasOne(d => d.Teachers)
                    .WithMany(p => p.ClassRoom)
                    .HasForeignKey(d => d.TeachersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teachers_ClassRoom");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentsClassRoom>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassRoomId).HasColumnName("ClassRoomID");

                entity.Property(e => e.StudentsId).HasColumnName("StudentsID");

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.StudentsClassRoom)
                    .HasForeignKey(d => d.ClassRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassRoom_StudentsClassRoom");

                entity.HasOne(d => d.Students)
                    .WithMany(p => p.StudentsClassRoom)
                    .HasForeignKey(d => d.StudentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_StudentsClassRoom");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SubjectsName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });
        }
    }
}
