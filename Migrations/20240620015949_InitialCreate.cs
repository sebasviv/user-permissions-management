using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPermisoId = table.Column<int>(type: "int", nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionType_TipoPermisoId",
                        column: x => x.TipoPermisoId,
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Vacaciones" },
                    { 2, "Enfermedad" },
                    { 3, "Permiso sin goce de sueldo" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "ApellidoEmpleado", "FechaPermiso", "NombreEmpleado", "TipoPermisoId" },
                values: new object[,]
                {
                    { 1, "Perez", new DateTime(2024, 6, 19, 20, 59, 48, 842, DateTimeKind.Local).AddTicks(5594), "Juan", 1 },
                    { 2, "Gomez", new DateTime(2024, 6, 19, 20, 59, 48, 842, DateTimeKind.Local).AddTicks(5612), "Maria", 2 },
                    { 3, "Rodriguez", new DateTime(2024, 6, 19, 20, 59, 48, 842, DateTimeKind.Local).AddTicks(5614), "Pedro", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_TipoPermisoId",
                table: "Permission",
                column: "TipoPermisoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionType");
        }
    }
}
