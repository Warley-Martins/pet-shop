using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    /// <summary>
    /// Produtoo vendido
    /// </summary>
    public abstract class Produto
    {

        /// <summary>
        /// Id do produto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Potencial de felicidade do produto
        /// </summary>
        public int PotencialDeFelicidade { get; set; }
        /// <summary>
        /// Preço do produto
        /// </summary>
        public double Preco { get; set; }
        /// <summary>
        /// Construtor do produto
        /// </summary>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="preco">Preço do produto</param>
        /// <param name="potencialDeFelicidade">Potencial de deixar um animal feliz</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref preco="preco"/>, não pode ser menor ou igual a zero</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="potencialDeFelicidade"/>, não pode ser maior que 100 ou menor que -100</exception>
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
        /// <summary>
        /// Construtor default
        /// </summary>
        public Produto()
        {

        }
    }
}
