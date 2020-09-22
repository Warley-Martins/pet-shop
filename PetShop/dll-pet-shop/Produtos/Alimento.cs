using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{

    public class Alimento : Produto
    {
    
        public bool Usado { get; private set; }
        public Alimento(string descricao, double preco, int potencialDeFelicidade)
            : base(descricao, preco, potencialDeFelicidade)
        {

        }
        public Alimento()
        {

        }
        public void Comer()
        {
            this.Usado = true;
        }
        public override string ToString()
        {
            return $"{Id},{Descricao},{Preco},{PotencialDeFelicidade}";
        }
    }
}
