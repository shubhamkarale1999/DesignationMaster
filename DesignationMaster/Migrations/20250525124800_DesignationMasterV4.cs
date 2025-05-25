using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignationMaster.Migrations
{
    /// <inheritdoc />
    public partial class DesignationMasterV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Designation_tbl_CollegeMaster_CollegeId",
                table: "tbl_Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Designation_tbl_StreamMaster_StreamId",
                table: "tbl_Designation");

            migrationBuilder.AlterColumn<int>(
                name: "StreamId",
                table: "tbl_Designation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationCode",
                table: "tbl_Designation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "tbl_Designation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Designation_tbl_CollegeMaster_CollegeId",
                table: "tbl_Designation",
                column: "CollegeId",
                principalTable: "tbl_CollegeMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Designation_tbl_StreamMaster_StreamId",
                table: "tbl_Designation",
                column: "StreamId",
                principalTable: "tbl_StreamMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Designation_tbl_CollegeMaster_CollegeId",
                table: "tbl_Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Designation_tbl_StreamMaster_StreamId",
                table: "tbl_Designation");

            migrationBuilder.AlterColumn<int>(
                name: "StreamId",
                table: "tbl_Designation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesignationCode",
                table: "tbl_Designation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollegeId",
                table: "tbl_Designation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Designation_tbl_CollegeMaster_CollegeId",
                table: "tbl_Designation",
                column: "CollegeId",
                principalTable: "tbl_CollegeMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Designation_tbl_StreamMaster_StreamId",
                table: "tbl_Designation",
                column: "StreamId",
                principalTable: "tbl_StreamMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
