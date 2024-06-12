using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Express.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKorpaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kartica_AspNetUsers_korisnikId",
                table: "Kartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_idKorisnika",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_idKorisnika",
                table: "Korpa");

            migrationBuilder.AlterColumn<string>(
                name: "idKorisnika",
                table: "Korpa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "korisnikId",
                table: "Korpa",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "Kartica",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Korpaid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_korisnikId",
                table: "Korpa",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Korpaid",
                table: "AspNetUsers",
                column: "Korpaid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Korpa_Korpaid",
                table: "AspNetUsers",
                column: "Korpaid",
                principalTable: "Korpa",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kartica_AspNetUsers_korisnikId",
                table: "Kartica",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_korisnikId",
                table: "Korpa",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Korpa_Korpaid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Kartica_AspNetUsers_korisnikId",
                table: "Kartica");

            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_korisnikId",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_korisnikId",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Korpaid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "Korpa");

            migrationBuilder.DropColumn(
                name: "Korpaid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "idKorisnika",
                table: "Korpa",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "Kartica",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_idKorisnika",
                table: "Korpa",
                column: "idKorisnika",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kartica_AspNetUsers_korisnikId",
                table: "Kartica",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_idKorisnika",
                table: "Korpa",
                column: "idKorisnika",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
