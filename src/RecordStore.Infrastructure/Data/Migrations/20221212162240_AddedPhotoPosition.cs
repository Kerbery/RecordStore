using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Infrastructure.Migrations
{
    public partial class AddedPhotoPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Photos");
        }
    }
}
