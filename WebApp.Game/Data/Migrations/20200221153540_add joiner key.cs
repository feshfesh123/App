using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Game.Data.Migrations
{
    public partial class addjoinerkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joiners_AspNetUsers_UserId",
                table: "Joiners");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Joiners",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Joiners_AspNetUsers_UserId",
                table: "Joiners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joiners_AspNetUsers_UserId",
                table: "Joiners");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Joiners",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Joiners_AspNetUsers_UserId",
                table: "Joiners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
