using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaXPTO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BdFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FotografuaUrl",
                table: "Users",
                newName: "FotografiaUrl");

            migrationBuilder.RenameColumn(
                name: "HoraSolicitado",
                table: "AppointmentRequestItems",
                newName: "HoraSolicitada");

            migrationBuilder.RenameColumn(
                name: "FotografuaUrl",
                table: "AnonymousRequests",
                newName: "FotografiaUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FotografiaUrl",
                table: "Users",
                newName: "FotografuaUrl");

            migrationBuilder.RenameColumn(
                name: "HoraSolicitada",
                table: "AppointmentRequestItems",
                newName: "HoraSolicitado");

            migrationBuilder.RenameColumn(
                name: "FotografiaUrl",
                table: "AnonymousRequests",
                newName: "FotografuaUrl");
        }
    }
}
