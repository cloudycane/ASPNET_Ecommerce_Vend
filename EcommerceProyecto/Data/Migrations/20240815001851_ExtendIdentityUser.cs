using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consumidores");

            migrationBuilder.DropTable(
                name: "vendedores");

            migrationBuilder.AddColumn<string>(
                name: "ApellidosConsumidor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidosVendedor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumidorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consumidor_Correo_Electronico",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consumidor_Direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Consumidor_EsVerificado",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Consumidor_FechaNacimiento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consumidor_NumTelefono",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Consumidor_Valoracion",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo_Electronico",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EsVerificado",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreConsumidor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreVendedor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumTelefono",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TarjetCredito",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TarjetaDeCredito",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Valoracion",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VendedorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidosConsumidor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApellidosVendedor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConsumidorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_Correo_Electronico",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_EsVerificado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_NumTelefono",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Consumidor_Valoracion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Correo_Electronico",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EsVerificado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreConsumidor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreVendedor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumTelefono",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TarjetCredito",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TarjetaDeCredito",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Valoracion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "consumidores",
                columns: table => new
                {
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApellidosConsumidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsVerificado = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreConsumidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valoracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumidores", x => x.ConsumidorId);
                });

            migrationBuilder.CreateTable(
                name: "vendedores",
                columns: table => new
                {
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApellidosVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsVerificado = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaDeCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valoracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedores", x => x.VendedorId);
                });
        }
    }
}
