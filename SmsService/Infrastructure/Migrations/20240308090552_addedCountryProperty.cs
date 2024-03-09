using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmsService.Migrations
{
    public partial class addedCountryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Messages");
        }
    }
}
