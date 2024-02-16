﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actual_Project_V3.Migrations
{
    /// <inheritdoc />
    public partial class V49 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote");

            migrationBuilder.AddForeignKey(
                name: "FK_UpvoteDownvote_Posts_Post_Id",
                table: "UpvoteDownvote",
                column: "Post_Id",
                principalTable: "Posts",
                principalColumn: "Post_Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
