using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    public abstract class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PotencialDeFelicidade { get; set; }
        public double Preco { get; set; }
        public Produto(string descricao, double preco, int potencialDeFelicidade)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("A descrição não pode ser nula ou vazia");
            }
            if (preco <= 0)
            {
                throw new ArgumentException("O preço não pode ser igual o menor a zero");
            }
            if(potencialDeFelicidade < -100 || potencialDeFelicidade > 100)
            {
                throw new ArgumentException("O potencial não pode ser maior que 100 ou menor que -100");
            }
            this.Descricao = descricao;
            this.Preco = preco;
            this.PotencialDeFelicidade = potencialDeFelicidade;
        }
        public Produto()
        {

        }
    }
}
