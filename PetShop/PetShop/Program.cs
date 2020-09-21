using dll_pet_shop;
using dll_pet_shop.Animais;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PetShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\tBem vindo ao PetShop");
            int opcao;
            do
            {
                var mensagem = MenuOpcoes();
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 5);
            using (var contexto = new PetShopContext())
            {
                switch (opcao)
                {
                    case 1: // Printar Brinquedos
                        break;
                    case 2: // Printar Alimentos
                        break;
                    case 3: // Dar banho no pet
                        break;
                    case 4: // Cadastrar novo alimento
                        break;
                    case 5: // Cadastrar um novo brinquedo
                        break;
                    case 0: // Encerrar
                        return;
                }
            }
        }
        public static string MenuOpcoes()
        {
            return "\nDigite a opção desejada: " +
                   "\n(1). Olhar Brinquedos de Pets Para o Cliente" +
                   "\n(2). Olhar Alimentos de Pets Para o Cliente" +
                   "\n(3). Dar Banho no Pet" +
                   "\n(4). Cadastrar um Novo Alimento" +
                   "\n(5). Cadastrar um Novo Brinquedo" +
                   "\n(0). Encerrar" +
                   "\nOpção: ";

        }
        public static int AtribuirInt(string mensagem)
        {
            int opcao;
            do
            {
                try
                {
                    Console.Write(mensagem);
                    opcao = int.Parse(Console.ReadLine());
                    return opcao;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nNão foi possivel realizar operação!" +
                                      $"\nExceção lançada: {e.Message}");
                }
            } while (true);
        }


    public static void MostrarPrdutosAlimentos(PetShopContext contexto)
    {
        contexto.Alimentos.ToList();
    }
    public static void MostrarProdutosBrinquedos(PetShopContext contexto)
    {
        contexto.Brinquedos.ToList();
    }
    public static void ProcurarProduto(PetShopContext contexto)
    {
        var descricao = "xx";
        contexto.Alimentos.Where(x => x.Descricao == descricao).FirstOrDefault();
    }
    public static void VenderProduto()
    {

    }
}
}
