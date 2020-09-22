using System;

namespace PetShop
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\tBem vindo ao PetShop");
            int opcao;
            do
            {
                do
                {
                    var mensagem = MenuOpcoes();
                    opcao = AtribuirInt(mensagem);
                } while (opcao < 0 || opcao > 6);
                using (var contexto = new PetShopContext())
                {
                    //contexto.Database.EnsureCreated();
                    switch (opcao)
                    {
                        case 1: // Printar Brinquedos
                            MostrarProdutosBrinquedos(contexto);
                            break;
                        case 2: // Printar Alimentos
                            MostrarPrdutosAlimentos(contexto);
                            break;
                        case 3: // Dar banho no pet
                            DarBanho(contexto);
                            break;
                        case 4: // Cadastrar novo alimento
                            CadastrarAlimento(contexto);
                            break;
                        case 5: // Cadastrar um novo brinquedo
                            CadastrarBrinquedo(contexto);
                            break;
                        case 6: // Vender um produto
                            VenderProduto(contexto);
                            break;
                    }
                }
            } while (opcao != 0);
        }
    }
}
