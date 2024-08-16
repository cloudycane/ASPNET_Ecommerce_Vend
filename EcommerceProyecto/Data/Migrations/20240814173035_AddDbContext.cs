using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProyecto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carritos",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritos", x => x.CarritoId);
                });

            migrationBuilder.CreateTable(
                name: "consumidores",
                columns: table => new
                {
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreConsumidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosConsumidor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valoracion = table.Column<int>(type: "int", nullable: false),
                    EsVerificado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumidores", x => x.ConsumidorId);
                });

            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValoracionProducto = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsVerificado = table.Column<bool>(type: "bit", nullable: false),
                    ConIVA = table.Column<bool>(type: "bit", nullable: false),
                    ConDiscuento = table.Column<bool>(type: "bit", nullable: false),
                    ConPuntos = table.Column<bool>(type: "bit", nullable: false),
                    PaisProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LugarFabricacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Materiales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioProducto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "reseñas",
                columns: table => new
                {
                    ReseñaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaReseña = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reseñas", x => x.ReseñaId);
                });

            migrationBuilder.CreateTable(
                name: "transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha_Transaccion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacciones", x => x.TransaccionId);
                });

            migrationBuilder.CreateTable(
                name: "vendedores",
                columns: table => new
                {
                    VendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidosVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaDeCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo_Electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valoracion = table.Column<int>(type: "int", nullable: false),
                    EsVerificado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedores", x => x.VendedorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carritos");

            migrationBuilder.DropTable(
                name: "consumidores");

            migrationBuilder.DropTable(
                name: "ordenes");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "reseñas");

            migrationBuilder.DropTable(
                name: "transacciones");

            migrationBuilder.DropTable(
                name: "vendedores");
        }
    }
}
