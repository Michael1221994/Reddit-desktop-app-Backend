using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Members",
                table: "Subreddits");

            migrationBuilder.CreateTable(
                name: "JoinedSubreddits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sub_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinedSubreddits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JoinedSubreddits_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinedSubreddits_Subreddits_sub_id",
                        column: x => x.sub_id,
                        principalTable: "Subreddits",
                        principalColumn: "Sub_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinedSubreddits_sub_id",
                table: "JoinedSubreddits",
                column: "sub_id");

            migrationBuilder.CreateIndex(
                name: "IX_JoinedSubreddits_User_Id",
                table: "JoinedSubreddits",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinedSubreddits");

            migrationBuilder.AddColumn<string>(
                name: "Members",
                table: "Subreddits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
