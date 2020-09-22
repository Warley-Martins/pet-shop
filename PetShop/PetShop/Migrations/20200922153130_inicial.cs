using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: true),
                    PotencialDeFelicidade = table.Column<int>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Usado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brinquedos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: true),
                    PotencialDeFelicidade = table.Column<int>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Durabilidade = table.Column<int>(nullable: false),
                    Utilizado = table.Column<int>(nullable: false),
                    Usado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brinquedos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cachorro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Felicidade = table.Column<int>(nullable: false),
                    Limpo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cachorro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Felicidade = table.Column<int>(nullable: false),
                    Limpo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    CPF = table.Column<string>(maxLength: 15, nullable: true),
                    CachorroId = table.Column<int>(nullable: true),
                    GatoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Cachorro_CachorroId",
                        column: x => x.CachorroId,
                        principalTable: "Cachorro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Gatos_GatoId",
                        column: x => x.GatoId,
                        principalTable: "Gatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteAlimento",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    AlimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteAlimento", x => new { x.ClienteId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_ClienteAlimento_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteAlimento_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteBrinquedo",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    BrinquedoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteBrinquedo", x => new { x.ClienteId, x.BrinquedoId });
                    table.ForeignKey(
                        name: "FK_ClienteBrinquedo_Brinquedos_BrinquedoId",
                        column: x => x.BrinquedoId,
                        principalTable: "Brinquedos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteBrinquedo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteAlimento_AlimentoId",
                table: "ClienteAlimento",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteBrinquedo_BrinquedoId",
                table: "ClienteBrinquedo",
                column: "BrinquedoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CachorroId",
                table: "Clientes",
                column: "CachorroId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_GatoId",
                table: "Clientes",
                column: "GatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteAlimento");

            migrationBuilder.DropTable(
                name: "ClienteBrinquedo");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Brinquedos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cachorro");

            migrationBuilder.DropTable(
                name: "Gatos");
        }
    }
}
