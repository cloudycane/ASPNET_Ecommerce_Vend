using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDbC1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "VendedorId1",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VendedorId1",
                table: "Posts",
                column: "VendedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_vendedores_VendedorId1",
                table: "Posts",
                column: "VendedorId1",
                principalTable: "vendedores",
                principalColumn: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_vendedores_VendedorId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VendedorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VendedorId1",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ProductoId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
