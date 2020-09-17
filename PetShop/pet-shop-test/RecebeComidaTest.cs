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
            Alimento comida = new Alimento(descricao,10, potencialDeFelicidade);
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
        [InlineData("pate", 101)]
        [InlineData("pate", -101)]
        public void LancaArgumentExceptionRecebeProdutoComPotencialInvalido(string descricao, int potencial)
        {
            //Arranje
            Alimento alimento;
            //Assert
            Assert.Throws<ArgumentException>(
                //Acct
                () => alimento = new Alimento(descricao, 10, potencial)
                ); ;
        }
        [Theory]
        [InlineData("pate", 0, 10)]
        [InlineData("pate", -10, -10)]
        public void LancaArgumentExceptionRecebeProdutoComPrecoInvalido(string descricao, double preco,int potencial)
        {
            //Arranje
            Alimento alimento;
            //Assert
            Assert.Throws<ArgumentException>(
                //Acct
                () => alimento = new Alimento(descricao, preco, potencial)
                ); ;
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
            //Assert

        }
    }
}
