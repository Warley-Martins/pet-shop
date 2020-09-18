using dll_pet_shop;
using dll_pet_shop.Animais;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace pet_shop_test
{
    public class AcoesClienteTest
    {
        [Theory]
        [InlineData("pate", 2.25, 20, "Bob", "Pedro", "123.456.789-00")]
        public void ComprarEDarAlimentoParaOPet(string descricao, double preco, int potencial, string nomeAnimal,string nomePessoa, string cpf)
        {
            //Arranje
            var animal = new Cachorro(nomeAnimal);
            var cliente = new Cliente(nomePessoa, cpf, animal);
            var comida = new Alimento(descricao, preco, potencial);
            //Act
            cliente.ComprarComidaParaAnimal(comida);
            var obtido = cliente.DarAlimentoAoPet(comida.Descricao);
            var esperado = potencial;
            //Assert
            Assert.Equal(obtido, esperado);
        }

        [Theory]
        [InlineData("pate", 2.25, 20, "Bob", "Pedro", "123.456.789-00")]
        public void NaoPermiteDarUmAlimentoSemComprarAntes(string descricao, double preco, int potencial, string nomeAnimal, string nomePessoa, string cpf)
        {
            //Arranje
            var animal = new Cachorro(nomeAnimal);
            var cliente = new Cliente(nomePessoa, cpf, animal);
            var comida = new Alimento(descricao, preco, potencial);
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(
                    () => cliente.DarAlimentoAoPet(comida.Descricao)
            );
        }
        [Theory]
        [InlineData("bola", 2.25, 20,5, "Bob", "Pedro", "123.456.789-00")]
        public void ComprarEDarBrinquedoParaOPet(string descricao, double preco, int potencial, int durabilidade, string nomeAnimal, string nomePessoa, string cpf)
        {
            //Arranje
            var animal = new Cachorro(nomeAnimal);
            var cliente = new Cliente(nomePessoa, cpf, animal);
            var brinquedo = new Brinquedo(descricao, preco, potencial, durabilidade);
            //Act
            cliente.ComprarBrinquedoParaAnimal(brinquedo);
            var obtido = cliente.DarBrinquedoAoPet(brinquedo.Descricao);
            var esperado = potencial;
            //Assert
            Assert.Equal(obtido, esperado);
        }

        [Theory]
        [InlineData("bola", 2.25, 20, 5, "Bob", "Pedro", "123.456.789-00")]
        public void NaoPermiteDarUmBrinquedoSemComprarAntes(string descricao, double preco, int potencial, int durabilidade, string nomeAnimal, string nomePessoa, string cpf)
        {
            //Arranje
            var animal = new Cachorro(nomeAnimal);
            var cliente = new Cliente(nomePessoa, cpf, animal);
            var brinquedo = new Brinquedo(descricao, preco, potencial, durabilidade);
            //Assert
            Assert.Throws<NullReferenceException>(
            //Act
                    () => cliente.DarBrinquedoAoPet(brinquedo.Descricao)
            );
        }
    }
}
