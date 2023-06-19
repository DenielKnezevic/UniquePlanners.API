using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniquePlanners.Infrastructure.Migrations
{
    public partial class add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(2363), new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "DayOfBirth" },
                values: new object[] { new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(5478), new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(5492), new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(7517), new DateTime(2023, 6, 19, 12, 1, 6, 302, DateTimeKind.Local).AddTicks(7529) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Planner");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 15, 11, 56, 24, 862, DateTimeKind.Local).AddTicks(9722), new DateTime(2023, 5, 15, 11, 56, 24, 862, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "DayOfBirth" },
                values: new object[] { new DateTime(2023, 5, 15, 11, 56, 24, 863, DateTimeKind.Local).AddTicks(4674), new DateTime(2023, 5, 15, 11, 56, 24, 863, DateTimeKind.Local).AddTicks(4692), new DateTime(2023, 5, 15, 11, 56, 24, 863, DateTimeKind.Local).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 5, 15, 11, 56, 24, 863, DateTimeKind.Local).AddTicks(6925), new DateTime(2023, 5, 15, 11, 56, 24, 863, DateTimeKind.Local).AddTicks(6939) });
        }
    }
}
