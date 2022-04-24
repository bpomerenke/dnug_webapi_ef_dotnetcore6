using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonorApi.Migrations
{
    public partial class FixNamingAndSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.RenameTable(
                name: "Donors",
                newName: "donors",
                newSchema: "data");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "data",
                table: "donors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "data",
                table: "donors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "data",
                table: "donors",
                newName: "phone_number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_donors",
                schema: "data",
                table: "donors",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_donors",
                schema: "data",
                table: "donors");

            migrationBuilder.RenameTable(
                name: "donors",
                schema: "data",
                newName: "Donors");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Donors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Donors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Donors",
                newName: "PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "Id");
        }
    }
}
