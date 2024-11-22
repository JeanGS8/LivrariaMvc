using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaMvc.Migrations
{
    /// <inheritdoc />
    public partial class updateLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoPublicacao",
                table: "Livro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPublicacao",
                table: "Livro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Livro");

            migrationBuilder.AddColumn<int>(
                name: "AnoPublicacao",
                table: "Livro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
