using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsService.Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    MCC = table.Column<short>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.MCC);
                });

            migrationBuilder.CreateTable(
                name: "SMSMessages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    SendDateTime = table.Column<DateTime>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    IsSent = table.Column<bool>(nullable: false),
                    MCC = table.Column<int>(nullable: false),
                    Sender = table.Column<string>(maxLength: 100, nullable: false),
                    Receiver = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSMessages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CountryCodes",
                columns: new[] { "MCC", "Country", "CountryCode", "Price" },
                values: new object[] { (short)262, "Germany", "49", 0.055m });

            migrationBuilder.InsertData(
                table: "CountryCodes",
                columns: new[] { "MCC", "Country", "CountryCode", "Price" },
                values: new object[] { (short)232, "Austria", "43", 0.053m });

            migrationBuilder.InsertData(
                table: "CountryCodes",
                columns: new[] { "MCC", "Country", "CountryCode", "Price" },
                values: new object[] { (short)260, "Poland", "48", 0.032m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropTable(
                name: "SMSMessages");
        }
    }
}
