﻿// <auto-generated />
using System;
using Actual_Project_V3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240208101829_V3")]
    partial class V3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Actual_Project_V3.Models.Comment", b =>
                {
                    b.Property<int>("Comment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Comment_Id"));

                    b.Property<DateTime>("Commented_When")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Post_Id")
                        .HasColumnType("int");

                    b.Property<int>("Sub_Id")
                        .HasColumnType("int");

                    b.Property<string>("Thread_Order")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Comment_Id");

                    b.HasIndex("Post_Id");

                    b.HasIndex("Sub_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Post", b =>
                {
                    b.Property<int>("Post_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Post_Id"));

                    b.Property<string>("Flair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_Of_Comments")
                        .HasColumnType("int");

                    b.Property<int>("Number_Of_DownVotes")
                        .HasColumnType("int");

                    b.Property<int>("Number_of_Upvotes")
                        .HasColumnType("int");

                    b.Property<string>("Post_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Posted_When")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sub_Id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Video_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Post_Id");

                    b.HasIndex("Sub_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Subreddit", b =>
                {
                    b.Property<int>("Sub_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sub_Id"));

                    b.Property<string>("Allowed_Flairs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_When")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number_Of_Members")
                        .HasColumnType("int");

                    b.Property<string>("Sub_BackgroundImg_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sub_IconImg_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subreddit_Alt_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subreddit_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subreddit_Genre")
                        .HasColumnType("int");

                    b.Property<string>("Subreddit_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Sub_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Subreddits");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.UpvoteDownvote", b =>
                {
                    b.Property<int>("Rate_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rate_Id"));

                    b.Property<int?>("Comment_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Post_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Rate_Id");

                    b.HasIndex("Comment_Id");

                    b.HasIndex("Post_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UpvoteDownvote");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Comment", b =>
                {
                    b.HasOne("Actual_Project_V3.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("Post_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Actual_Project_V3.Models.Subreddit", "Subreddit")
                        .WithMany("Comments")
                        .HasForeignKey("Sub_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Actual_Project_V3.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Subreddit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Post", b =>
                {
                    b.HasOne("Actual_Project_V3.Models.Subreddit", "Subreddit")
                        .WithMany("Posts")
                        .HasForeignKey("Sub_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Actual_Project_V3.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Subreddit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Subreddit", b =>
                {
                    b.HasOne("Actual_Project_V3.Models.User", "User")
                        .WithMany("Subreddits")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.UpvoteDownvote", b =>
                {
                    b.HasOne("Actual_Project_V3.Models.Comment", "Comments")
                        .WithMany("UpvoteDownvotes")
                        .HasForeignKey("Comment_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Actual_Project_V3.Models.Post", "Post")
                        .WithMany("UpvoteDownvotes")
                        .HasForeignKey("Post_Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Actual_Project_V3.Models.User", "User")
                        .WithMany("UpvoteDownvotes")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Comment", b =>
                {
                    b.Navigation("UpvoteDownvotes");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UpvoteDownvotes");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.Subreddit", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Actual_Project_V3.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");

                    b.Navigation("Subreddits");

                    b.Navigation("UpvoteDownvotes");
                });
#pragma warning restore 612, 618
        }
    }
}
