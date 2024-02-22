using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_User_Id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_User_Id",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Reply_To",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Reply_To",
                table: "Comments",
                column: "Reply_To");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_Reply_To",
                table: "Comments",
                column: "Reply_To",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_Reply_To",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Reply_To",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Reply_To",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_Id",
                table: "Comments",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_User_Id",
                table: "Comments",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
