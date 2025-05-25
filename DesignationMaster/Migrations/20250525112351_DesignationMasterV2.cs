using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignationMaster.Migrations
{
    /// <inheritdoc />
    public partial class DesignationMasterV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "tbl_Designation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffType",
                table: "tbl_Designation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "tbl_Designation");

            migrationBuilder.DropColumn(
                name: "StaffType",
                table: "tbl_Designation");
        }
    }
}
