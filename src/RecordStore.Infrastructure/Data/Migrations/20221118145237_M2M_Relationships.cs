using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.Infrastructure.Migrations
{
    public partial class M2M_Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Records_RecordId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Records_RecordId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Styles_Records_RecordId",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Styles_RecordId",
                table: "Styles");

            migrationBuilder.DropIndex(
                name: "IX_Genres_RecordId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RecordId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryRecord",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecord", x => new { x.CategoriesId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_CategoryRecord_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRecord_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreRecord",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreRecord", x => new { x.GenresId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_GenreRecord_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreRecord_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordStyle",
                columns: table => new
                {
                    RecordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StylesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordStyle", x => new { x.RecordsId, x.StylesId });
                    table.ForeignKey(
                        name: "FK_RecordStyle_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordStyle_Styles_StylesId",
                        column: x => x.StylesId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22747656-aa1d-4260-93b3-f6767f35ec6d"),
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "82056e1a-01b8-49a2-8aa1-a7d13793cb76", new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7423eb5-e11b-4a66-9d04-d64a464148bb"),
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "7811cf2b-f588-40b7-bf4b-851aa4c4c5a7", new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35eccb0-55ef-4df8-99ad-7b3de0ba8b6b"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb1c3bb-b6dd-4625-b987-98f3e4bbbbe5", new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "AQAAAAEAACcQAAAAEIReJQldzy9EEmoNDWpKwO1O82HaJsqAH4ZMuGOxtwGK7/BWvjRtkKIb7AvBpXQhiQ==", "d1dc4c23-e3a4-4569-931b-9531d3a0ec99" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecord_RecordsId",
                table: "CategoryRecord",
                column: "RecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreRecord_RecordsId",
                table: "GenreRecord",
                column: "RecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordStyle_StylesId",
                table: "RecordStyle",
                column: "StylesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRecord");

            migrationBuilder.DropTable(
                name: "GenreRecord");

            migrationBuilder.DropTable(
                name: "RecordStyle");

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Styles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecordId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22747656-aa1d-4260-93b3-f6767f35ec6d"),
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "89f7af26-0904-40d0-9f57-b94edc3a0c34", new DateTimeOffset(new DateTime(2022, 11, 17, 14, 32, 38, 582, DateTimeKind.Unspecified).AddTicks(5257), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7423eb5-e11b-4a66-9d04-d64a464148bb"),
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "b9bedd48-1039-4bf9-8874-6117cdb77e38", new DateTimeOffset(new DateTime(2022, 11, 17, 14, 32, 38, 582, DateTimeKind.Unspecified).AddTicks(5021), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e35eccb0-55ef-4df8-99ad-7b3de0ba8b6b"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de5ea696-40bd-4bf7-9aa0-e19ccac97cca", new DateTimeOffset(new DateTime(2022, 11, 17, 12, 32, 38, 582, DateTimeKind.Unspecified).AddTicks(5600), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAEAACcQAAAAEEvFtehfvCYy1bk+xQGGOkv5HQXin1sFRgcuRp3cgHDi+5PGfzppHFkhWQlx0Bikxw==", "914473a9-b63b-40f8-8a57-3ccb707f57cb" });

            migrationBuilder.CreateIndex(
                name: "IX_Styles_RecordId",
                table: "Styles",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_RecordId",
                table: "Genres",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RecordId",
                table: "Categories",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Records_RecordId",
                table: "Categories",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Records_RecordId",
                table: "Genres",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Styles_Records_RecordId",
                table: "Styles",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id");
        }
    }
}
