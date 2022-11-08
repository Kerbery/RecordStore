using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Infrastructure.Data.Migrations
{
    public partial class AddAdminUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4639d1-8bce-489e-a8ba-d6f18f0b1f9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e476de60-59d0-4ec5-b151-5ac68b0fd8ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22747656-AA1D-4260-93B3-F6767F35EC6D", "c9fbb216-3001-46fb-9ab5-1cb3002ea4c8", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F7423EB5-E11B-4A66-9D04-D64A464148BB", "c4c7f979-8200-47ca-bf9a-398ae639f09f", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B", 0, "5cdefd93-4a01-439d-a370-cd63fbf49bf3", "admin@mail.com", false, false, null, null, "Admin", "AQAAAAEAACcQAAAAEA8uxih4Fb6hZxsWpr0s0+xC7w1Po9bl6ALe2ASZkE+OKTKUq9kbzCAvINe3yABAaQ==", null, false, "7a7895cb-3859-4f46-84f8-066d24b3f3f4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "F7423EB5-E11B-4A66-9D04-D64A464148BB", "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22747656-AA1D-4260-93B3-F6767F35EC6D");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "F7423EB5-E11B-4A66-9D04-D64A464148BB", "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F7423EB5-E11B-4A66-9D04-D64A464148BB");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e4639d1-8bce-489e-a8ba-d6f18f0b1f9f", "a8bf39f7-2f6c-4f2e-b2bd-45d091a79031", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e476de60-59d0-4ec5-b151-5ac68b0fd8ab", "118a7d38-51b4-4a86-926c-6061c5e0e108", "Admin", "Admin" });
        }
    }
}
