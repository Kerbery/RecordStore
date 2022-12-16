using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Infrastructure.Migrations
{
    public partial class UpdatedOnDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Conditions_RecordConditionId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Formats_FormatId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Releases_ReleaseId",
                table: "Records");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35eccb0-55ef-4df8-99ad-7b3de0ba8b6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be938583-cf6d-4791-9fc6-6243cce460c4", "AQAAAAEAACcQAAAAEEtQ+iWjf+MOU9Lt71QwhpI+l7bkc8oEFn0UUzQH6BKX9NG8MF4vz6Slj26KeMwPXg==", "14f5df95-5b25-4771-b981-7c0eda6a594f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Conditions_RecordConditionId",
                table: "Records",
                column: "RecordConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Formats_FormatId",
                table: "Records",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Releases_ReleaseId",
                table: "Records",
                column: "ReleaseId",
                principalTable: "Releases",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Conditions_RecordConditionId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Formats_FormatId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Releases_ReleaseId",
                table: "Records");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35eccb0-55ef-4df8-99ad-7b3de0ba8b6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8920f4a0-98e1-4000-bd24-8ebe974070c1", "AQAAAAEAACcQAAAAEFUdluxCtWb1vCThvKm1S/lFOwr5kbcVqa7CXuiovbqhY90CKLHKe3ND90gobJLQJg==", "1703b5c9-5ee6-4d68-b7da-41dac870c7d0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Conditions_RecordConditionId",
                table: "Records",
                column: "RecordConditionId",
                principalTable: "Conditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Formats_FormatId",
                table: "Records",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Releases_ReleaseId",
                table: "Records",
                column: "ReleaseId",
                principalTable: "Releases",
                principalColumn: "Id");
        }
    }
}
