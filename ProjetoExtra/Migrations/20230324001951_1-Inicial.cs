using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoExtra.Migrations
{
    public partial class _1Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "Sessoes");

            migrationBuilder.DropColumn(
                name: "TipoPerfil",
                table: "Perfis");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Perfis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_UsuarioId",
                table: "Sessoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfis",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Users_UsuarioId",
                table: "Perfis",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Users_UsuarioId",
                table: "Sessoes",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Users_UsuarioId",
                table: "Perfis");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Users_UsuarioId",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Sessoes_UsuarioId",
                table: "Sessoes");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_UsuarioId",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Perfis");

            migrationBuilder.AddColumn<int>(
                name: "IdPerfil",
                table: "Sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoPerfil",
                table: "Perfis",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
