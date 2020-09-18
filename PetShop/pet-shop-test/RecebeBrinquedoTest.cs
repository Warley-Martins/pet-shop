using dll_pet_shop;
using dll_pet_shop.Animais;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace pet_shop_test
{
    public class RecebeBrinquedoTest
    {
        [Theory]
        [InlineData("bolinha com apito", 30, 5)]
        public void FicaFelizReceberBrinquedo(string descricao, int potencial, int durabilidade)
        {
            //Arranje
            var cao = new Cachorro("Bilu");
            var gato = new Gato("Theo");
            var brinquedo = new Brinquedo(descricao, 2, potencial, durabilidade);
            //Act
            var esperado = true;
            var obtidoCao = cao.ReceberBrinquedo(brinquedo);
            var obtidoGato = gato.ReceberBrinquedo(brinquedo);
            var obtido = obtidoCao == obtidoGato;
            //Assert
            Assert.Equal(potencial, obtidoGato);
            Assert.Equal(obtido,esperado);
        }
        [Theory]
        [InlineData("Bolinha", 30, 5)]
        public void UtilizarBrinquedoAcabar(string descricao, int potencial, int durabilidade)
        {
            //Arranje
            var cao = new Cachorro("Rico");
            var gato = new Gato("Luna");
            var brinquedoCao = new Brinquedo(descricao, 2, potencial, durabilidade);
            var brinquedoGato = new Brinquedo(descricao, 2, potencial, durabilidade);
            //Act
            do
            {
                gato.Brincar(brinquedoGato);
            } while (brinquedoGato.Usado == false);
            do
            {
                cao.Brincar(brinquedoCao);
            } while (brinquedoCao.Usado == false);
            var esperado = true;
            var obtido = brinquedoGato.Usado;
            var obtidoTotal = brinquedoCao.Usado == brinquedoGato.Usado;
            //Assert
            Assert.Equal(esperado, obtido);
            Assert.Equal(esperado, obtidoTotal);
        }
        [Theory]
        [InlineData("pitu", "bola", 100, 20, "bolinha", 10, 5, 1)]
        [InlineData("pitu", "espinho", 100, 10, "espinhoMenor", 5, 10, -1)]
        public void ConfereFelicidadeMaximaEMinima(string nome, string descricao, int potencial, int durabilidade, string descricao2, int potencial2, int durabilidade2, int sinal)
        {
            //Arranje
            var cao = new Cachorro(nome);
            var brinquedo = new Brinquedo(descricao, 10, (sinal * potencial), durabilidade);
            var brinquedo2 = new Brinquedo(descricao2, 10, (sinal * potencial2), durabilidade2);
            //Act
            var esperado = sinal * 100;
            cao.Brincar(brinquedo);
            var obtido = cao.Brincar(brinquedo2);
            //Assert
            Assert.Equal(esperado, obtido);
        }
        [Theory]
        [InlineData("bolinha", 101, 2)]
        [InlineData("bolinha", -101, 2)]
        [InlineData("bolinha", 10, 0)]
        public void LancaArgumentExceptionRecebeBrinquedoInvalido(string descricao, int potencial, int durabilidade)
        {
            //Arranje
            Brinquedo brinquedo;
            //Asseert
            Assert.Throws<ArgumentException>(
                //Act
                () => brinquedo = new Brinquedo(descricao, 10, potencial, durabilidade)
                ); ;
        }

    }
}
