﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinwireArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Bitmap = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsPromo = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireArticles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinwireArticles");
        }
    }
}
