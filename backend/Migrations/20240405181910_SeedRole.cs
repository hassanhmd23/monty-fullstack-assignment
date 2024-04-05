using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class SeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01554538-afc4-4acc-9ac9-0aef00260a23", "b5f8cd01-3ff9-485e-91d2-838e8d5c1189", "Admin", "ADMIN" },
                    { "d1975417-9fe1-4c67-ac5f-1a1083db215e", "4c77b203-099b-4bae-92e6-7a0f0ccb9122", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01554538-afc4-4acc-9ac9-0aef00260a23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1975417-9fe1-4c67-ac5f-1a1083db215e");
        }
    }
}
