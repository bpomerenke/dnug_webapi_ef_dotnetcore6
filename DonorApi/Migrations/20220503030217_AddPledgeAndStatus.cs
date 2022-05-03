using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DonorApi.Migrations
{
    public partial class AddPledgeAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "current_drive_status",
                schema: "data",
                table: "donors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "pledges",
                schema: "data",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    donor_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pledges", x => x.id);
                    table.ForeignKey(
                        name: "FK_pledges_donors_donor_id",
                        column: x => x.donor_id,
                        principalSchema: "data",
                        principalTable: "donors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pledges_donor_id",
                schema: "data",
                table: "pledges",
                column: "donor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pledges",
                schema: "data");

            migrationBuilder.DropColumn(
                name: "current_drive_status",
                schema: "data",
                table: "donors");
        }
    }
}
