using dll_pet_shop;
using dll_pet_shop.Animais;
using System;
using Xunit;

namespace pet_shop_test
{
    public class RecebeComidaTest
    {
        [Theory]
        [InlineData("pate", 20)]
        [InlineData("pate", -10)]
        public void RecebeUmAlimetoEConfereOGrauDeFelicidade(string descricao, int potencialDeFelicidade)
        {
            //Arranje
            Gato gato = new Gato("Duke");
            Alimento comida = new Alimento(descricao, 10, potencialDeFelicidade);
            //Act
            var esperado = potencialDeFelicidade;
            var obtido = gato.ReceberComida(comida);
            //Asseert
            Assert.Equal(esperado, obtido);          
        }
        [Fact]
        public void LancaNullReferenceExceptionAnimalRecebeAlimentoNulo()
        {
            //Arranje
            Cachorro cao = new Cachorro("lucke");
            Alimento t = null;
            //Assert
            Assert.Throws<NullReferenceException>(
                //Act
                () => cao.ReceberComida(t)
                );
        }
        [Theory]
        [InlineData("pitu","pate", 10)]
        public void FicaInfelizReceberUmAlimentoUsado(string nome, string descricao, int potencial)
        {
            //Arranje
            Alimento alimento = new Alimento(descricao, 10, potencial);
            Gato gato = new Gato(nome);
            Cachorro cao = new Cachorro(nome);
            //Act
            cao.ReceberComida(alimento);   //  10 
            gato.ReceberComida(alimento);  //  10
            var esperado = potencial - 10;
            var obtidoCao = cao.ReceberComida(alimento);
            var obtidoGato = gato.ReceberComida(alimento);
            var CaoEGatoEsperado = true;
            var CaoEGatoObtido = obtidoGato == obtidoCao;
            //Assert
            Assert.Equal(CaoEGatoEsperado, CaoEGatoObtido);
        }
        [Theory]
        [InlineData("pitu", "pate", 10)]
        public void FicaFelizReceberUmAlimento(string nome, string descricao, int potencial)
        {
            //Arranje
            Alimento alimento = new Alimento(descricao, 10, potencial);
            Gato gato = new Gato(nome);
            Cachorro cao = new Cachorro(nome);
            //Act
            cao.ReceberComida(alimento);   //  10 
            gato.ReceberComida(alimento);  //  10
            var esperado = potencial;
            var obtido = cao.Felicidade;
            //Assert
            Assert.Equal(esperado, obtido);
        }
        [Theory]
        [InlineData("pitu", "pate", 100, "banana", 10, 1)]
        [InlineData("pitu", "pate", 100, "banana", 10, -1)]
        public void ConfereFelicidadeMaximaEMinima(string nome, string descricao, int potencial, string descricao2, int potencial2, int sinal)
        {
            //Arranje
            var cao = new Cachorro(nome);
            var alimento = new Alimento(descricao, 10 , (sinal * potencial));
            var alimento2 = new Alimento(descricao2, 10, (sinal * potencial2));
            //Act
            var esperado = sinal * 100;
            cao.ReceberComida(alimento);
            var obtido = cao.ReceberComida(alimento2);
            //Assert
            Assert.Equal(esperado, obtido);
        }
        
    }
}
