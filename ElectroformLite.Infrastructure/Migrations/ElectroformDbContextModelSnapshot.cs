﻿// <auto-generated />
using System;
using ElectroformLite.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    [DbContext(typeof(ElectroformDbContext))]
    partial class ElectroformDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AliasTemplateTemplate", b =>
                {
                    b.Property<Guid>("AliasTemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AliasTemplatesId", "TemplatesId");

                    b.HasIndex("TemplatesId");

                    b.ToTable("AliasTemplateTemplate", (string)null);
                });

            modelBuilder.Entity("DataGroupTemplateDataTemplate", b =>
                {
                    b.Property<Guid>("DataGroupTemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataTemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DataGroupTemplatesId", "DataTemplatesId");

                    b.HasIndex("DataTemplatesId");

                    b.ToTable("DataGroupTemplateDataTemplate", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Alias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AliasTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AliasTemplateId");

                    b.HasIndex("DataGroupId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Aliases", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.AliasTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataGroupTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DataGroupTemplateId");

                    b.ToTable("AliasTemplates", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Data", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DataGroupId");

                    b.HasIndex("DataTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserData", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataGroupTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DataGroupTemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("DataGroups", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroupTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataGroupTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DataGroupTypeId");

                    b.ToTable("DataGroupTemplates", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroupType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DataGroupTypes", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Placeholder")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DataTypeId");

                    b.ToTable("DataTemplates", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DataTypes", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Templates", (string)null);
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AliasTemplateTemplate", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.AliasTemplate", null)
                        .WithMany()
                        .HasForeignKey("AliasTemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.Template", null)
                        .WithMany()
                        .HasForeignKey("TemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataGroupTemplateDataTemplate", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataGroupTemplate", null)
                        .WithMany()
                        .HasForeignKey("DataGroupTemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.DataTemplate", null)
                        .WithMany()
                        .HasForeignKey("DataTemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Alias", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.AliasTemplate", "AliasTemplate")
                        .WithMany("Aliases")
                        .HasForeignKey("AliasTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.DataGroup", "DataGroup")
                        .WithMany("Aliases")
                        .HasForeignKey("DataGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.Document", null)
                        .WithMany("Aliases")
                        .HasForeignKey("DocumentId");

                    b.Navigation("AliasTemplate");

                    b.Navigation("DataGroup");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.AliasTemplate", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataGroupTemplate", "DataGroupTemplate")
                        .WithMany("AliasTemplates")
                        .HasForeignKey("DataGroupTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataGroupTemplate");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Data", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataGroup", "DataGroup")
                        .WithMany("UserData")
                        .HasForeignKey("DataGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.DataTemplate", "DataTemplate")
                        .WithMany("UserData")
                        .HasForeignKey("DataTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany("UserData")
                        .HasForeignKey("UserId");

                    b.Navigation("DataGroup");

                    b.Navigation("DataTemplate");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroup", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataGroupTemplate", "DataGroupTemplate")
                        .WithMany("DataGroups")
                        .HasForeignKey("DataGroupTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany("DataGroups")
                        .HasForeignKey("UserId");

                    b.Navigation("DataGroupTemplate");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroupTemplate", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataGroupType", "DataGroupType")
                        .WithMany("DataGroupTemplates")
                        .HasForeignKey("DataGroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataGroupType");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataTemplate", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.DataType", "DataType")
                        .WithMany("DataTemplates")
                        .HasForeignKey("DataTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataType");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Document", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.Template", null)
                        .WithMany("Documents")
                        .HasForeignKey("TemplateId");

                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany("Documents")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ElectroformLite.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.AliasTemplate", b =>
                {
                    b.Navigation("Aliases");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroup", b =>
                {
                    b.Navigation("Aliases");

                    b.Navigation("UserData");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroupTemplate", b =>
                {
                    b.Navigation("AliasTemplates");

                    b.Navigation("DataGroups");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataGroupType", b =>
                {
                    b.Navigation("DataGroupTemplates");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataTemplate", b =>
                {
                    b.Navigation("UserData");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.DataType", b =>
                {
                    b.Navigation("DataTemplates");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Document", b =>
                {
                    b.Navigation("Aliases");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.Template", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("ElectroformLite.Domain.Models.User", b =>
                {
                    b.Navigation("DataGroups");

                    b.Navigation("Documents");

                    b.Navigation("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}
