using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Express.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKorpaModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Korpa_Korpaid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_korisnikId",
                table: "Korpa");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Korpa_Korpaid",
                table: "Proizvod");

            migrationBuilder.RenameColumn(
                name: "Korpaid",
                table: "Proizvod",
                newName: "KorpaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvod_Korpaid",
                table: "Proizvod",
                newName: "IX_Proizvod_KorpaId");

            migrationBuilder.RenameColumn(
                name: "ukupnaCijena",
                table: "Korpa",
                newName: "UkupnaCijena");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "Korpa",
                newName: "KorisnikId");

            migrationBuilder.RenameColumn(
                name: "idKorisnika",
                table: "Korpa",
                newName: "IdKorisnika");

            migrationBuilder.RenameColumn(
                name: "brojKartice",
                table: "Korpa",
                newName: "BrojKartice");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Korpa",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Korpa_korisnikId",
                table: "Korpa",
                newName: "IX_Korpa_KorisnikId");

            migrationBuilder.RenameColumn(
                name: "Korpaid",
                table: "AspNetUsers",
                newName: "KorpaId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Korpaid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_KorpaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Korpa_KorpaId",
                table: "AspNetUsers",
                column: "KorpaId",
                principalTable: "Korpa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId",
                table: "Korpa",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Korpa_KorpaId",
                table: "Proizvod",
                column: "KorpaId",
                principalTable: "Korpa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Korpa_KorpaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_AspNetUsers_KorisnikId",
                table: "Korpa");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Korpa_KorpaId",
                table: "Proizvod");

            migrationBuilder.RenameColumn(
                name: "KorpaId",
                table: "Proizvod",
                newName: "Korpaid");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvod_KorpaId",
                table: "Proizvod",
                newName: "IX_Proizvod_Korpaid");

            migrationBuilder.RenameColumn(
                name: "UkupnaCijena",
                table: "Korpa",
                newName: "ukupnaCijena");

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "Korpa",
                newName: "korisnikId");

            migrationBuilder.RenameColumn(
                name: "IdKorisnika",
                table: "Korpa",
                newName: "idKorisnika");

            migrationBuilder.RenameColumn(
                name: "BrojKartice",
                table: "Korpa",
                newName: "brojKartice");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Korpa",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Korpa_KorisnikId",
                table: "Korpa",
                newName: "IX_Korpa_korisnikId");

            migrationBuilder.RenameColumn(
                name: "KorpaId",
                table: "AspNetUsers",
                newName: "Korpaid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_KorpaId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Korpaid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Korpa_Korpaid",
                table: "AspNetUsers",
                column: "Korpaid",
                principalTable: "Korpa",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_AspNetUsers_korisnikId",
                table: "Korpa",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Korpa_Korpaid",
                table: "Proizvod",
                column: "Korpaid",
                principalTable: "Korpa",
                principalColumn: "id");
        }
    }
}
