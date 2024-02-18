using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V59 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote",
                column: "Comment_Id",
                principalTable: "Comments",
                principalColumn: "Comment_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Comments_Comment_Id",
                table: "UpvoteDownvote",
                column: "Comment_Id",
                principalTable: "Comments",
                principalColumn: "Comment_Id");
        }
    }
}
