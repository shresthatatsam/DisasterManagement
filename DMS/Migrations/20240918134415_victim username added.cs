using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class victimusernameadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "victims",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_victims_user_id",
                table: "victims",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_victims_AspNetUsers_user_id",
                table: "victims",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_victims_AspNetUsers_user_id",
                table: "victims");

            migrationBuilder.DropIndex(
                name: "IX_victims_user_id",
                table: "victims");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "victims");
        }
    }
}
