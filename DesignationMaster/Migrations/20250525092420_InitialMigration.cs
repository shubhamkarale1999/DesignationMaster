using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignationMaster.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CollegeMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CollegeMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StreamMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StreamMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Designation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    DesignationCode = table.Column<int>(type: "int", nullable: false),
                    DesignationAcronym = table.Column<string>(type: "varchar(50)", nullable: false),
                    DesignationName = table.Column<string>(type: "varchar(150)", nullable: false),
                    StreamId = table.Column<int>(type: "int", nullable: false),
                    RolesAndResponsibilities = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(150)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(150)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Designation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Designation_tbl_CollegeMaster_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "tbl_CollegeMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Designation_tbl_StreamMaster_StreamId",
                        column: x => x.StreamId,
                        principalTable: "tbl_StreamMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Designation_CollegeId",
                table: "tbl_Designation",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Designation_StreamId",
                table: "tbl_Designation",
                column: "StreamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Designation");

            migrationBuilder.DropTable(
                name: "tbl_CollegeMaster");

            migrationBuilder.DropTable(
                name: "tbl_StreamMaster");
        }
    }
}
