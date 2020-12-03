using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendas.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroEndereco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroEndereco", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CadastroEntregador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Entregador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone_Entregador = table.Column<int>(type: "int", nullable: false),
                    GetRG_Entregador = table.Column<int>(type: "int", nullable: false),
                    Habilitação_Entregador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroEntregador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opcao_Pagamento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroPessoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    RG = table.Column<int>(type: "int", nullable: false),
                    Data_Nascimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroPessoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Cliente = table.Column<int>(type: "int", nullable: false),
                    id_Entregador = table.Column<int>(type: "int", nullable: false),
                    id_Endereco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercadoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Tipo_Mercadoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade_Mercadoria = table.Column<int>(type: "int", nullable: false),
                    Nome_Mercadoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadoria", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastroEndereco");

            migrationBuilder.DropTable(
                name: "CadastroEntregador");

            migrationBuilder.DropTable(
                name: "CadastroPagamento");

            migrationBuilder.DropTable(
                name: "CadastroPessoal");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Mercadoria");
        }
    }
}
