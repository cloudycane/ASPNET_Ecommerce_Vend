using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDbC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "VendedorId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProductoId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VendedorId",
                table: "Posts",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_VendedorId",
                table: "Posts",
                column: "VendedorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_VendedorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VendedorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "VendedorId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
