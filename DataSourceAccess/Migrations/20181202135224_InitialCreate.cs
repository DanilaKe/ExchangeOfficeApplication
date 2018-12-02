using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataSourceAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AccountType = table.Column<byte>(nullable: false)
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
                    ContributedCurrency = table.Column<int>(nullable: false),
                    TargetCurrency = table.Column<int>(nullable: false),
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
                    Name = table.Column<string>(nullable: true),
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
                name: "HistoryOfExchanges",
                columns: table => new
                {
                    ExchangeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateId = table.Column<int>(nullable: true),
                    CurrencyExchangeId = table.Column<int>(nullable: false),
                    ContributedAmount = table.Column<decimal>(nullable: false),
                    IssuedAmount = table.Column<decimal>(nullable: false),
                    CustumerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryOfExchanges", x => x.ExchangeId);
                    table.ForeignKey(
                        name: "FK_HistoryOfExchanges_CurrencyExchanges_CurrencyExchangeId",
                        column: x => x.CurrencyExchangeId,
                        principalTable: "CurrencyExchanges",
                        principalColumn: "CurrencyExchangeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryOfExchanges_Custumers_CustumerId",
                        column: x => x.CustumerId,
                        principalTable: "Custumers",
                        principalColumn: "CustumerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryOfExchanges_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfExchanges_CurrencyExchangeId",
                table: "HistoryOfExchanges",
                column: "CurrencyExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfExchanges_CustumerId",
                table: "HistoryOfExchanges",
                column: "CustumerId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfExchanges_DateId",
                table: "HistoryOfExchanges",
                column: "DateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "HistoryOfExchanges");

            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "Custumers");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
