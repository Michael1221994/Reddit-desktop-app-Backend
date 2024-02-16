using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote");

            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote",
                column: "Comment_Id",
                principalTable: "Comments",
                principalColumn: "Comment_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote");

            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_Post_Id",
                table: "Comments",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote",
                column: "Comment_Id",
                principalTable: "Comments",
                principalColumn: "Comment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id");
        }
    }
}
