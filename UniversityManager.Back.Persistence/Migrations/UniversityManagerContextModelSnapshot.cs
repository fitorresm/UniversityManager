﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityManager.Back.Persistence.Contexts;

#nullable disable

namespace UniversityManager.Back.Persistence.Migrations
{
    [DbContext(typeof(UniversityManagerContext))]
    partial class UniversityManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniversityManager.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdSemesters")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniversityManager.Domain.Note", b =>
                {
                    b.Property<int?>("IdCourse")
                        .HasColumnType("int");

                    b.Property<int?>("IdSemester")
                        .HasColumnType("int");

                    b.Property<int?>("IdStudent")
                        .HasColumnType("int");

                    b.Property<int?>("IdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("IdTeacher")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("ValueNote")
                        .HasColumnType("real");

                    b.HasKey("IdCourse", "IdSemester", "IdStudent", "IdSubject");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Student_Subject", b =>
                {
                    b.Property<int?>("IdStudent")
                        .HasColumnType("int");

                    b.Property<int?>("IdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("IdSemester")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("IdStudent", "IdSubject");

                    b.HasIndex("StudentId");

                    b.ToTable("Relationship_Students_Subjects");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Subject_Course", b =>
                {
                    b.Property<int?>("IdSubject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdSubject"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSubject");

                    b.ToTable("Relationship_Subjects_Courses");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Teacher_Subject", b =>
                {
                    b.Property<int?>("IdSubject")
                        .HasColumnType("int");

                    b.Property<int?>("IdSemester")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("IdTeacher")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSubject", "IdSemester");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Relationship_Teachers_Subjects");
                });

            modelBuilder.Entity("UniversityManager.Domain.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Relationship_Student_SubjectIdStudent")
                        .HasColumnType("int");

                    b.Property<int?>("Relationship_Student_SubjectIdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("UniversityManager.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GraduationCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniversityManager.Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<float>("MaxAprove")
                        .HasColumnType("real");

                    b.Property<float>("MinAprove")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Optional")
                        .HasColumnType("bit");

                    b.Property<int?>("Relationship_Student_SubjectIdStudent")
                        .HasColumnType("int");

                    b.Property<int?>("Relationship_Student_SubjectIdSubject")
                        .HasColumnType("int");

                    b.Property<int?>("Relationship_Subject_CourseIdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Relationship_Subject_CourseIdSubject");

                    b.HasIndex("Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UniversityManager.Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Relationship_Teacher_SubjectIdSemester")
                        .HasColumnType("int");

                    b.Property<int?>("Relationship_Teacher_SubjectIdSubject")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Relationship_Teacher_SubjectIdSubject", "Relationship_Teacher_SubjectIdSemester");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Student_Subject", b =>
                {
                    b.HasOne("UniversityManager.Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Teacher_Subject", b =>
                {
                    b.HasOne("UniversityManager.Domain.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.HasOne("UniversityManager.Domain.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniversityManager.Domain.Semester", b =>
                {
                    b.HasOne("UniversityManager.Domain.Relationship_Student_Subject", null)
                        .WithMany("Semesters")
                        .HasForeignKey("Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject");
                });

            modelBuilder.Entity("UniversityManager.Domain.Subject", b =>
                {
                    b.HasOne("UniversityManager.Domain.Relationship_Subject_Course", null)
                        .WithMany("Subjects")
                        .HasForeignKey("Relationship_Subject_CourseIdSubject");

                    b.HasOne("UniversityManager.Domain.Relationship_Student_Subject", null)
                        .WithMany("Subjects")
                        .HasForeignKey("Relationship_Student_SubjectIdStudent", "Relationship_Student_SubjectIdSubject");
                });

            modelBuilder.Entity("UniversityManager.Domain.Teacher", b =>
                {
                    b.HasOne("UniversityManager.Domain.Relationship_Teacher_Subject", null)
                        .WithMany("Teachers")
                        .HasForeignKey("Relationship_Teacher_SubjectIdSubject", "Relationship_Teacher_SubjectIdSemester");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Student_Subject", b =>
                {
                    b.Navigation("Semesters");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Subject_Course", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("UniversityManager.Domain.Relationship_Teacher_Subject", b =>
                {
                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
