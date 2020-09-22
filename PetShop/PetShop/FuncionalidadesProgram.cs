using dll_pet_shop;
using dll_pet_shop.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop
{
    public partial class Program
    {
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
        public static void CadastrarAlimento(PetShopContext contexto)
        {
            var mensagem = "Digite a descrição do alimento: ";
            var descricao = AtribuirString(mensagem);
            mensagem = "Digite o preço: ";
            var preco = AtribuirDouble(mensagem);
            mensagem = "Insira o potencial de felicidade do alimento: ";
            var potencial = AtribuirInt(mensagem);
            contexto.Alimentos.Add(new Alimento(descricao, preco, potencial));
            contexto.SaveChanges();
        }
        public static void CadastrarBrinquedo(PetShopContext contexto)
        {
            var mensagem = "Digite a descrição do brinquedo: ";
            var descricao = AtribuirString(mensagem);
            mensagem = "Digite o preço: ";
            var preco = AtribuirDouble(mensagem);
            mensagem = "Insira o potencial de felicidade do brinquedo: ";
            var potencial = AtribuirInt(mensagem);
            mensagem = "Digite a durabilidade do brinquedo: ";
            var durabilidade = AtribuirInt(mensagem);
            contexto.Brinquedos.Add(new Brinquedo(descricao, preco, potencial, durabilidade));
            contexto.SaveChanges();
        }
        public static void MostrarProdutosBrinquedos(PetShopContext contexto)
        {
            foreach (var item in contexto.Brinquedos)
            {
                PrintarBrinquedo(item);
            }
        }
        public static void MostrarPrdutosAlimentos(PetShopContext contexto)
        {
            foreach (var item in contexto.Alimentos)
            {
                PrintarAlimento(item);
            }
        }
        public static void DarBanho(PetShopContext contexto)
        {
            var mensagem = "\nO cliente já possui cadastro?" +
                           "\n(1). Sim" +
                           "\n(0). Não" +
                           "\nOpção: ";
            int opcao;
            Cliente cliente = null;
            do
            {
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 1);
            do
            {
                switch (opcao)
                {
                    case 1:
                        cliente = ProcurarCliente(contexto);
                        break;
                    case 0:
                        cliente = RealizarCadastro(contexto);
                        break;
                }
            } while (cliente == null);
            do
            {
                mensagem = "\nO valor do banho é: R$30,00" +
                           "\n(1). sim" +
                           "\n(0). Não" +
                           "\nResposta: ";
                opcao = AtribuirInt(mensagem);
            } while (opcao != 1);
            cliente.LevarPetParaTomarBanho();
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
        }
        public static Cliente RealizarCadastro(PetShopContext contexto)
        {
            var mensagem = "Digite o nome: ";
            var nome = AtribuirString(mensagem);
            mensagem = "Digite o cpf: ";
            var cpf = AtribuirString(mensagem);
            mensagem = "\nVocê possui:" +
                       "\n(1). Gato" +
                       "\n(0). Cachorro" +
                       "\nOpção: ";
            var opcaoPet = AtribuirInt(mensagem);
            mensagem = "Digite o nome do pet: ";
            var nomePet = AtribuirString(mensagem);
            if (opcaoPet == 1)
            {
                return new Cliente(nome, cpf, new Gato(nomePet));
            }
            return new Cliente(nome, cpf, new Cachorro(nomePet));
        }
        public static Alimento ProcurarAlimento(PetShopContext contexto)
        {
            var mensagem = "\nDigite o Id do produto: ";
            var id = AtribuirInt(mensagem);
            return contexto.Alimentos.Where(x => x.Id == id).FirstOrDefault();
        }
        public static Brinquedo ProcurarBrinquedo(PetShopContext contexto)
        {
            var mensagem = "\nDigite o Id do produto: ";
            var id = AtribuirInt(mensagem);
            return contexto.Brinquedos.Where(x => x.Id == id).FirstOrDefault();
        }
        public static Cliente ProcurarCliente(PetShopContext contexto)
        {
            Cliente cliente = null;
            do
            {
                var mensagem = "Digite o CPF do cliente: ";
                var cpf = AtribuirString(mensagem);
                cliente = contexto.Clientes.Where(x => x.CPF == cpf).FirstOrDefault();
            } while (cliente == null);
            return cliente;
        }
        public static void VenderProduto(PetShopContext contexto)
        {
            int opcao;
            int opcaoProduto;
            string mensagem;
            mensagem = "\nO cliente ja possui cadastro?" +
                       "\n(1). Sim" +
                       "\n(0). Não" +
                       "\nOpção: ";
            do
            {
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 1);
            Cliente cliente = null;
            do
            {
                if (opcao == 1)
                {
                    cliente = ProcurarCliente(contexto);
                }
                else
                {
                    cliente = RealizarCadastro(contexto);
                }
            } while (cliente == null);
            contexto.SaveChanges();
            do
            {
                mensagem = "\nVocê deseja comprar:" +
                           "\n(1). Alimento" +
                           "\n(0). Brinquedo" +
                           "\nOpção: ";
                opcaoProduto = AtribuirInt(mensagem);
            } while (opcaoProduto < 0 || opcaoProduto > 1);
            if (opcaoProduto == 1)
            {
                VenderAlimento(contexto, cliente);
            }
            else
            {
                VenderBrinquedo(contexto, cliente);
            }
        }
        public static void VenderAlimento(PetShopContext contexto, Cliente cliente)
        {
            int opcao;
            string mensagem;
            Alimento alimento = null;
            do
            {
                alimento = ProcurarAlimento(contexto);
            } while (alimento == null);
            PrintarAlimento(alimento);
            do
            {
                mensagem = "\nDeseja confirmar: " +
                           "\n(1). Sim" +
                           "\n(0). Não" +
                           "\nOpção: ";
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 1);
            if (opcao == 1)
            {
                cliente.ComprarComidaParaAnimal(alimento);
                contexto.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nCompra cancelada!");
            }

        }
        public static void VenderBrinquedo(PetShopContext contexto, Cliente cliente)
        {
            int opcao;
            string mensagem;
            Brinquedo Brinquedo = null;
            do
            {
                Brinquedo = ProcurarBrinquedo(contexto);
            } while (Brinquedo == null);
            PrintarBrinquedo(Brinquedo);
            do
            {
                mensagem = "\nDeseja confirmar: " +
                           "\n(1). Sim" +
                           "\n(0). Não" +
                           "\nOpção: ";
                opcao = AtribuirInt(mensagem);
            } while (opcao < 0 || opcao > 1);
            if (opcao == 1)
            {
                cliente.ComprarBrinquedoParaAnimal(Brinquedo);
                contexto.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nCompra cancelada!");
            }

        }
        public static void PrintarAlimento(Alimento item)
        {
            Console.WriteLine($"\nId: {item.Id}" +
                              $"\nDescrição: {item.Descricao}" +
                              $"\nPreço: R$ {item.Preco}" +
                              $"\nPotencial de Felicidade: {item.PotencialDeFelicidade}");

        }
        public static void PrintarBrinquedo(Brinquedo item)
        {
            Console.WriteLine($"\nId: {item.Id}" +
                              $"\nDescrição: {item.Descricao}" +
                              $"\nPreço: R$ {item.Preco}" +
                              $"\nPotencial de Felicidade: {item.PotencialDeFelicidade}" +
                              $"\nDurabilidade: {item.Durabilidade}");
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
        public static string AtribuirString(string mensagem)
        {
            string texto;
            do
            {
                Console.Write(mensagem);
                texto = Console.ReadLine();
            } while (String.IsNullOrEmpty(texto));
            return texto;
        }
        public static double AtribuirDouble(string mensagem)
        {
            double opcao;
            do
            {
                try
                {
                    Console.Write(mensagem);
                    opcao = double.Parse(Console.ReadLine());
                    return opcao;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nNão foi possivel realizar operação!" +
                                      $"\nExceção lançada: {e.Message}");
                }
            } while (true);
        }

    }
}
