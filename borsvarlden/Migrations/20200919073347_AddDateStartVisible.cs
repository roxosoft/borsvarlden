﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddDateStartVisible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateStartVisible",
                table: "FinwireNews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateStartVisible",
                table: "FinwireNews");
        }
    }
}
