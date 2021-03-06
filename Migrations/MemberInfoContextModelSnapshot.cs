﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using react_slingshot_project.Entities;
using System;

namespace reactslingshotproject.Migrations
{
    [DbContext(typeof(MemberInfoContext))]
    partial class MemberInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("react_slingshot_project.Entities.Member", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Subgroupid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("lname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("Subgroupid");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("react_slingshot_project.Entities.Subgroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminId");

                    b.Property<string>("desciption")
                        .IsRequired()
                        .HasMaxLength(240);

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("AdminId");

                    b.ToTable("Subgroups");
                });

            modelBuilder.Entity("react_slingshot_project.Entities.Member", b =>
                {
                    b.HasOne("react_slingshot_project.Entities.Subgroup")
                        .WithMany("Members")
                        .HasForeignKey("Subgroupid");
                });

            modelBuilder.Entity("react_slingshot_project.Entities.Subgroup", b =>
                {
                    b.HasOne("react_slingshot_project.Entities.Member", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
