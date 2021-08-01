using Microsoft.EntityFrameworkCore.Migrations;

namespace Vouchers.DAL.Migrations
{
    public partial class indexAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Deal",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_ExternalID",
                table: "Voucher",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_DealName",
                table: "Deal",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Voucher_ExternalID",
                table: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_Deal_DealName",
                table: "Deal");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Deal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
