using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateInteractionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IntDate",
                table: "Interactions",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IntDate",
                table: "Interactions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Clients_ClientId",
                table: "Interactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
