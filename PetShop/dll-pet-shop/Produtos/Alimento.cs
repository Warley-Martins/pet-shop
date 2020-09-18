using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    /// <summary>
    /// Alimento
    /// </summary>
    public class Alimento : Produto
    {
        /// <summary>
        /// Descrição do alimento
        /// </summary>
        public bool Usado { get; private set; }
        /// <summary>
        /// Construtor de Alimento
        /// </summary>
        /// <param name="descricao">Descrição do alimento</param>
        /// <param name="preco">Preço do alimento</param>
        /// <param name="potencialDeFelicidade">Potencial de deixar o animal feliz</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref preco="preco"/>, não pode ser menor ou igual a zero</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="potencialDeFelicidade"/>, não pode ser maior que 100 ou menor que -100</exception>
        public Alimento(string descricao, double preco, int potencialDeFelicidade)
            : base(descricao, preco, potencialDeFelicidade)
        {

        }
        /// <summary>
        /// Come um alimento
        /// </summary>
        public void Comer()
        {
            this.Usado = true;
        }
        
    }
}
