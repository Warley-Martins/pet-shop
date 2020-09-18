using dll_pet_shop;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace pet_shop_test
{
    public class ValidacaoProdutoTest
    {
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
        public void LancaArgumentExceptionRecebeProdutoComPrecoInvalido(string descricao, double preco, int potencial)
        {
            //Arranje
            Alimento alimento;
            //Assert
            Assert.Throws<ArgumentException>(
                //Acct
                () => alimento = new Alimento(descricao, preco, potencial)
                ); ;
        }

    }
}
