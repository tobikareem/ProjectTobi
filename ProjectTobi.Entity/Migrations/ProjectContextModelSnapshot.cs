﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTobi.Entity.DbContext;

namespace ProjectTobi.Entity.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tobs")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTobi.Model.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Title")
                        .HasName("IX_tobs_Blog_Title");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ProjectTobi.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectTobi.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProjectTobi.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProjectTobi.Model.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PermissionName")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("PermissionName")
                        .IsUnique()
                        .HasName("IX_tobs_Permission_PermissionName")
                        .HasFilter("[PermissionName] IS NOT NULL");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ProjectTobi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("DisplayName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varchar(200)")
                        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FirstName")
                        .IsUnique()
                        .HasName("IX_tobs_User_FirstName")
                        .HasFilter("[FirstName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectTobi.Model.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("ProjectTobi.Model.Blog", b =>
                {
                    b.HasOne("ProjectTobi.Model.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTobi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTobi.Model.Comment", b =>
                {
                    b.HasOne("ProjectTobi.Model.Blog", null)
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTobi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTobi.Model.Image", b =>
                {
                    b.HasOne("ProjectTobi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectTobi.Model.UserPermission", b =>
                {
                    b.HasOne("ProjectTobi.Model.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTobi.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
