using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmsService.Migrations
{
    public partial class updatedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Messages",
                type: "nvarchar(480)",
                maxLength: 480,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(480)",
                oldMaxLength: 480,
                oldNullable: true);
        }
    }
}
