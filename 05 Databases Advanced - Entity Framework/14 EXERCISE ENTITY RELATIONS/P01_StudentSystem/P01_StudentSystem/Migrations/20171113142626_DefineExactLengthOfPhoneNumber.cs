using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Migrations
{
    public partial class DefineExactLengthOfPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "char(10)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "varchar(10)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
