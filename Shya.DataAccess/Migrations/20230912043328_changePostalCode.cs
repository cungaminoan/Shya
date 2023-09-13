using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shya.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePostalCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AspNetUsers",
                newName: "PostalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AspNetUsers",
                newName: "PostalCode");
        }
    }
}
