using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Infrastructure.Migrations
{
    public partial class AddedStaticSecurityStamp : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ReleaseId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecordConditionId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormatId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22747656-aa1d-4260-93b3-f6767f35ec6d"),
                column: "ConcurrencyStamp",
                value: "599CB2A4-B261-4ECD-A428-B0DC42A64C04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7423eb5-e11b-4a66-9d04-d64a464148bb"),
                column: "ConcurrencyStamp",
                value: "F9770056-5580-4CD9-AFFA-4764FE94C01D");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ReleaseId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RecordConditionId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FormatId",
                table: "Records",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22747656-aa1d-4260-93b3-f6767f35ec6d"),
                column: "ConcurrencyStamp",
                value: "82056e1a-01b8-49a2-8aa1-a7d13793cb76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7423eb5-e11b-4a66-9d04-d64a464148bb"),
                column: "ConcurrencyStamp",
                value: "7811cf2b-f588-40b7-bf4b-851aa4c4c5a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35eccb0-55ef-4df8-99ad-7b3de0ba8b6b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb1c3bb-b6dd-4625-b987-98f3e4bbbbe5", "AQAAAAEAACcQAAAAEIReJQldzy9EEmoNDWpKwO1O82HaJsqAH4ZMuGOxtwGK7/BWvjRtkKIb7AvBpXQhiQ==", "d1dc4c23-e3a4-4569-931b-9531d3a0ec99" });

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Conditions_RecordConditionId",
                table: "Records",
                column: "RecordConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Formats_FormatId",
                table: "Records",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Releases_ReleaseId",
                table: "Records",
                column: "ReleaseId",
                principalTable: "Releases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
