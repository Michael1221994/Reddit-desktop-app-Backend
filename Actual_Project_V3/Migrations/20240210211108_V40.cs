using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
