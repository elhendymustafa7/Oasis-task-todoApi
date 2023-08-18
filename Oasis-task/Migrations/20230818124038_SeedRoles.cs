using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oasis_task.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] {  "User", "User".ToUpper(), Guid.NewGuid().ToString() }
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] {  "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] {  "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}
