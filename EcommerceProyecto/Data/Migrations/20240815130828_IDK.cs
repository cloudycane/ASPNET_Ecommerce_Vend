using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class IDK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_VendedorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_vendedores_VendedorId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VendedorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VendedorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VendedorId1",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "vendedores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "vendedores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "VendedorId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "VendedorId1",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VendedorId",
                table: "Posts",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VendedorId1",
                table: "Posts",
                column: "VendedorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_VendedorId",
                table: "Posts",
                column: "VendedorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_vendedores_VendedorId1",
                table: "Posts",
                column: "VendedorId1",
                principalTable: "vendedores",
                principalColumn: "VendedorId");
        }
    }
}
