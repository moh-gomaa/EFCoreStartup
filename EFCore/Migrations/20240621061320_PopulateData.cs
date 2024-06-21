using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class PopulateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Employees (Name) VALUES ('Predefined Employee 2');
                                   INSERT INTO Employees (Name) VALUES ('Predefined Employee 3');
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Employees WHERE NAME = 'Predefined Employee 2' OR Name = 'Predefined Employee 3';");
        }
    }
}
