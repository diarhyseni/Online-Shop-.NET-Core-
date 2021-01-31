using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Shop.Data.Migrations
{
    public partial class BaseEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Mice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Mice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Mice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Mice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Joysticks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Joysticks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Joysticks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Joysticks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Headsets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Headsets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Headsets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Headsets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GameConsoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "GameConsoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "GameConsoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "GameConsoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Chairs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Chairs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Chairs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Chairs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Joysticks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Joysticks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Joysticks");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Joysticks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GameConsoles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "GameConsoles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "GameConsoles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "GameConsoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Chairs");
        }
    }
}
