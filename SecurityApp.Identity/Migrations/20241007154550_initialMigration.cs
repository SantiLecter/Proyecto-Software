using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityApp.Identity.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "934b6a0a-69b0-4833-ac1d-ac17dfecd1d8",
                column: "ConcurrencyStamp",
                value: "cdd1508f-98a9-41b5-91ba-08cba371ee80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfa6789c-ae15-4704-ae59-9f5628f1379c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92565a67-7bd5-49b9-b6f3-e304a9124e82", "AQAAAAEAACcQAAAAELlIRlgODrCrYu116SebGY1SCzhMbNJVW9ZMAe0cqWdBvFui/jMlkc9TmMsdSGyCGg==", "5ed7fda7-5b3d-4b5b-8deb-f85cad57813e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "934b6a0a-69b0-4833-ac1d-ac17dfecd1d8",
                column: "ConcurrencyStamp",
                value: "6884aac0-0f68-4292-a5f2-8898746d4006");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfa6789c-ae15-4704-ae59-9f5628f1379c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d67d28f-f850-4eef-b841-77b2fa433c81", "AQAAAAEAACcQAAAAEJH2GxjtWVSxTGQwZZB3DrgrI9ZTYXDyA13HKiDjvl4o2GELir49f2yh+rFwk2r3hw==", "9b6d64d6-d5cd-4064-a9f7-7b7e2eebbf94" });
        }
    }
}
