using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace P01_FootballBetting.Migrations
{
    public partial class ChangeTeamBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Budget",
                table: "Teams",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Budget",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
