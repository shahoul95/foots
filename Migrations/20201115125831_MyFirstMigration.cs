using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace foots.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "membre",
                columns: table => new
                {
                    id_membres = table.Column<int>(type: "int(255)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    login = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    mot_passes = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    nom = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    prenom = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    phone = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    equipe = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    poste = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_membres);
                });

            migrationBuilder.CreateTable(
                name: "amis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_membre = table.Column<int>(type: "int(11)", nullable: false),
                    id_amis = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amis", x => x.id);
                    table.ForeignKey(
                        name: "amis_ibfk_2",
                        column: x => x.id_amis,
                        principalTable: "membre",
                        principalColumn: "id_membres",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "amis_ibfk_1",
                        column: x => x.id_membre,
                        principalTable: "membre",
                        principalColumn: "id_membres",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "message_recu",
                columns: table => new
                {
                    ids = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    destinataire = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    expediteur = table.Column<int>(type: "int(11)", nullable: false),
                    message = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    heure = table.Column<DateTime>(type: "date", nullable: false),
                    vue = table.Column<int>(type: "int(1)", nullable: true),
                    non_vue = table.Column<int>(type: "int(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ids);
                    table.ForeignKey(
                        name: "message_recu_ibfk_1",
                        column: x => x.expediteur,
                        principalTable: "membre",
                        principalColumn: "id_membres",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "id_amis",
                table: "amis",
                column: "id_amis");

            migrationBuilder.CreateIndex(
                name: "ids",
                table: "amis",
                column: "id_membre");

            migrationBuilder.CreateIndex(
                name: "id_membre",
                table: "message_recu",
                column: "expediteur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amis");

            migrationBuilder.DropTable(
                name: "message_recu");

            migrationBuilder.DropTable(
                name: "membre");
        }
    }
}
