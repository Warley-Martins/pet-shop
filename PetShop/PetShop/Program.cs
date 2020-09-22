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
                    switch (opcao)
                    {
                        case 1: 
                            MostrarProdutosBrinquedos(contexto);
                            break;
                        case 2: 
                            MostrarPrdutosAlimentos(contexto);
                            break;
                        case 3: 
                            DarBanho(contexto);
                            break;
                        case 4: 
                            CadastrarAlimento(contexto);
                            break;
                        case 5: 
                            CadastrarBrinquedo(contexto);
                            break;
                        case 6: 
                            VenderProduto(contexto);
                            break;
                    }
                }
            } while (opcao != 0);
        }
    }
}
