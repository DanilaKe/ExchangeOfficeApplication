using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSourceAccess.Migrations
{
    public partial class model1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    AccountTypeValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchanges",
                columns: table => new
                {
                    CurrencyExchangeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContributedCurrencyValue = table.Column<int>(nullable: false),
                    TargetCurrencyValue = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    ActualStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchanges", x => x.CurrencyExchangeId);
                });

            migrationBuilder.CreateTable(
                name: "Custumers",
                columns: table => new
                {
                    CustumerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    DailyLimit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custumers", x => x.CustumerId);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    DateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    ExchangeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateId = table.Column<int>(nullable: false),
                    CurrencyExchangeId = table.Column<int>(nullable: false),
                    ContributedAmount = table.Column<decimal>(nullable: false),
                    IssuedAmount = table.Column<decimal>(nullable: false),
                    CustumerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.ExchangeId);
                    table.ForeignKey(
                        name: "FK_Exchanges_CurrencyExchanges_CurrencyExchangeId",
                        column: x => x.CurrencyExchangeId,
                        principalTable: "CurrencyExchanges",
                        principalColumn: "CurrencyExchangeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchanges_Custumers_CustumerId",
                        column: x => x.CustumerId,
                        principalTable: "Custumers",
                        principalColumn: "CustumerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exchanges_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_CurrencyExchangeId",
                table: "Exchanges",
                column: "CurrencyExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_CustumerId",
                table: "Exchanges",
                column: "CustumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_DateId",
                table: "Exchanges",
                column: "DateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "Custumers");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
