using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendedorIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "VendedorId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "VendedorId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
