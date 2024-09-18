using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VictimId",
                table: "disasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_disasters_VictimId",
                table: "disasters",
                column: "VictimId");

            migrationBuilder.AddForeignKey(
                name: "FK_disasters_victims_VictimId",
                table: "disasters",
                column: "VictimId",
                principalTable: "victims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_disasters_victims_VictimId",
                table: "disasters");

            migrationBuilder.DropIndex(
                name: "IX_disasters_VictimId",
                table: "disasters");

            migrationBuilder.DropColumn(
                name: "VictimId",
                table: "disasters");
        }
    }
}
