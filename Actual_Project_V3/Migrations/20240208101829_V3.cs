using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subreddits",
                columns: table => new
                {
                    Sub_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subreddit_Genre = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subreddit_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subreddit_Alt_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subreddit_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_IconImg_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_BackgroundImg_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number_Of_Members = table.Column<int>(type: "int", nullable: false),
                    Created_When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Allowed_Flairs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subreddits", x => x.Sub_Id);
                    table.ForeignKey(
                        name: "FK_Subreddits_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posted_When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sub_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number_Of_Comments = table.Column<int>(type: "int", nullable: false),
                    Number_of_Upvotes = table.Column<int>(type: "int", nullable: false),
                    Number_Of_DownVotes = table.Column<int>(type: "int", nullable: false),
                    Flair = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Post_Id);
                    table.ForeignKey(
                        name: "FK_Posts_Subreddits_Sub_Id",
                        column: x => x.Sub_Id,
                        principalTable: "Subreddits",
                        principalColumn: "Sub_Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    Sub_Id = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thread_Order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commented_When = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Posts",
                        principalColumn: "Post_Id");
                    table.ForeignKey(
                        name: "FK_Comments_Subreddits_Sub_Id",
                        column: x => x.Sub_Id,
                        principalTable: "Subreddits",
                        principalColumn: "Sub_Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UpvoteDownvote",
                columns: table => new
                {
                    Rate_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Post_Id = table.Column<int>(type: "int", nullable: true),
                    Comment_Id = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpvoteDownvote", x => x.Rate_Id);
                    table.ForeignKey(
                        name: "FK_UpvoteDownvote_Comments_Comment_Id",
                        column: x => x.Comment_Id,
                        principalTable: "Comments",
                        principalColumn: "Comment_Id");
                    table.ForeignKey(
                        name: "FK_UpvoteDownvote_Posts_Post_Id",
                        column: x => x.Post_Id,
                        principalTable: "Posts",
                        principalColumn: "Post_Id");
                    table.ForeignKey(
                        name: "FK_UpvoteDownvote_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Post_Id",
                table: "Comments",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Sub_Id",
                table: "Comments",
                column: "Sub_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_Id",
                table: "Comments",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Sub_Id",
                table: "Posts",
                column: "Sub_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_User_Id",
                table: "Posts",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subreddits_User_Id",
                table: "Subreddits",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteDownvote_Comment_Id",
                table: "UpvoteDownvote",
                column: "Comment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteDownvote_Post_Id",
                table: "UpvoteDownvote",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteDownvote_User_Id",
                table: "UpvoteDownvote",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpvoteDownvote");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subreddits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
