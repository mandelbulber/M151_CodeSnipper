using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeSnipper_Web.Data.Migrations
{
    public partial class CodeSnippetsLanguageProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CodeSnippets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "CodeSnippets");
        }
    }
}
