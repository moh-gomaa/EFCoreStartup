using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBlogsTableColumnsSpecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Blogs",
                newName: "BlogUrl");

            migrationBuilder.AlterColumn<string>(
                name: "BlogUrl",
                table: "Blogs",
                type: "varchar(250)",
                nullable: false,
                comment: "The url of the blog",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BlogName",
                table: "Blogs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "The name of the blog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogName",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogUrl",
                table: "Blogs",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldComment: "The url of the blog");
        }
    }
}
