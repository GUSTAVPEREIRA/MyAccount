using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAccount.Migrations
{
    public partial class UserMigratonV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 22, 17, 49, 38, 601, DateTimeKind.Utc).AddTicks(8564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 21, 21, 47, 47, 365, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TbUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 22, 17, 49, 38, 596, DateTimeKind.Utc).AddTicks(7343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 21, 21, 47, 47, 360, DateTimeKind.Utc).AddTicks(6272));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 21, 21, 47, 47, 365, DateTimeKind.Utc).AddTicks(6575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 22, 17, 49, 38, 601, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TbUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "TbUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 21, 21, 47, 47, 360, DateTimeKind.Utc).AddTicks(6272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 22, 17, 49, 38, 596, DateTimeKind.Utc).AddTicks(7343));
        }
    }
}
