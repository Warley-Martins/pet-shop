using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    public class Brinquedo : Produto
    {
        public int Durabilidade { get; private set; }
        public int Utilizado { get; private set; }
        public bool Usado { get; private set; }
        public Brinquedo(string descricao, double preco, int PotencialDeFelicidade, int durabilidade)
            : base(descricao, preco, PotencialDeFelicidade)
        {
            if (durabilidade <= 0)
            {
                throw new ArgumentException("O brinquedo não pode ter durabilidade menor ou igual a zero");
            }
            this.Durabilidade = durabilidade;
            this.Usado = false;
        }
        public Brinquedo()
        {

        }
        public bool UtilizarBrinquedo()
        {
            if(Usado == true)
            {
                return false;
            }
            this.Utilizado++;
            if(this.Utilizado == Durabilidade)
            {
                this.Usado = true;
            }
            return true;
        }
        public override string ToString()
        {
            return $"{Id},{Descricao},{Preco},{PotencialDeFelicidade},{Durabilidade}";
        }
    }
}
