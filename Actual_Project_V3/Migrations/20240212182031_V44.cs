using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Flair",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts",
                column: "Sub_Id",
                principalTable: "Subreddits",
                principalColumn: "Sub_Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subreddits_Sub_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Subreddits_Sub_Id",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Flair",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
