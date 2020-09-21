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
                        MostrarProdutosBrinquedos(contexto);
                        break;
                    case 2: // Printar Alimentos
                        MostrarPrdutosAlimentos(contexto);
                        break;
                    case 3: // Dar banho no pet
                        DarBanho(contexto);
                        break;
                    case 4: // Cadastrar novo alimento
                        break;
                    case 5: // Cadastrar um novo brinquedo
                        break;
                    case 6: // Vender um produto
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
                   "\n(6). Vender um Produto Para o Cliente" +
                   "\n(0). Encerrar" +
                   "\nOpção: ";

        }

        public static void MostrarProdutosBrinquedos(PetShopContext contexto)
        {
            foreach (var item in contexto.Brinquedos)
            {
                var texto = item.ToString().Split(',');
                Console.WriteLine($"\nId: {texto[0]}" +
                                  $"\nDescrição: {texto[1]}" +
                                  $"\nPreço: R$ {texto[2]}" +
                                  $"\nPotencial de Felicidade: {texto[3]}" +
                                  $"\nDurabilidade: {texto[4]}");
            }
        }
        public static void MostrarPrdutosAlimentos(PetShopContext contexto)
        {
            foreach (var item in contexto.Alimentos)
            {
                var texto = item.ToString().Split(',');
                Console.WriteLine($"\nId: {texto[0]}" +
                                  $"\nDescrição: {texto[1]}" +
                                  $"\nPreço: R$ {texto[2]}" +
                                  $"\nPotencial de Felicidade: {texto[3]}");
            }
        }
        public static void DarBanho(PetShopContext contexto)
        {
            var mensagem = "\nO cliente já possui cadastro?" +
                           "\n(1). Sim" +
                           "\n(0). Não" +
                           "\nOpção: ";
            int opcao;
            Cliente cliente;
            do
            {
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 1);
            do
            {
                switch (opcao)
                {
                    case 1:
                        cliente = RealizarCadastro(contexto);
                        break;
                    case 0:
                        cliente = ProcurarCliente(contexto);
                        break;
                }
            } while (cliente == null);
        }

        public static void ProcurarProduto(PetShopContext contexto)
        {
            var descricao = "xx";
            contexto.Alimentos.Where(x => x.Descricao == descricao).FirstOrDefault();
        }
        public static void VenderProduto()
        {

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


        public static void AtribuirString(string mensagem)
        {
        }
    }
}
