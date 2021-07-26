using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateInteraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Interactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmployeeId",
                table: "Interactions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmployeeId",
                table: "Interactions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmployeeId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmployeeId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Interactions");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmpId",
                table: "Interactions",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmpId",
                table: "Interactions",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
