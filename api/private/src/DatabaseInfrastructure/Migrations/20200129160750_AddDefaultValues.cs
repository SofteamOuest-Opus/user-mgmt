using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseInfrastructure.Migrations
{
    public partial class AddDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03b9c8f8-2ecb-294f-7e4b-96d4b9c1e98a"), "Employee" },
                    { new Guid("3cbe94ae-32d5-4ace-0258-84819eb08c98"), "Manager" },
                    { new Guid("45f3141c-650c-b5c2-121c-9764e8c78063"), "Human resource manager" },
                    { new Guid("35484dd9-6eae-39c1-1bf6-bfc2528aaa02"), "Top management" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9f35ba62-b5a6-ea8b-6413-14e7a4635cf6"), "Nantes" },
                    { new Guid("c1cf125f-0664-56d1-d3c4-ed54f00556f9"), "Rennes" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07debdda-ca9b-65ac-b939-992610420dfc"), "Internship" },
                    { new Guid("715ffd55-b3c7-ff74-fa93-588a507c2aaa"), "Subcontractor" },
                    { new Guid("9120b0e2-928b-feae-d5e6-eb1c3b944984"), "Freelancer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("03b9c8f8-2ecb-294f-7e4b-96d4b9c1e98a"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("35484dd9-6eae-39c1-1bf6-bfc2528aaa02"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("3cbe94ae-32d5-4ace-0258-84819eb08c98"));

            migrationBuilder.DeleteData(
                table: "Occupations",
                keyColumn: "Id",
                keyValue: new Guid("45f3141c-650c-b5c2-121c-9764e8c78063"));

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("9f35ba62-b5a6-ea8b-6413-14e7a4635cf6"));

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: new Guid("c1cf125f-0664-56d1-d3c4-ed54f00556f9"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("07debdda-ca9b-65ac-b939-992610420dfc"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("715ffd55-b3c7-ff74-fa93-588a507c2aaa"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("9120b0e2-928b-feae-d5e6-eb1c3b944984"));
        }
    }
}
