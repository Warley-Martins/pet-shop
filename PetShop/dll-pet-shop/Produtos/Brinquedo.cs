using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    /// <summary>
    /// Classe brinquedo
    /// </summary>
    public class Brinquedo : Produto
    {
        public int Id { get; }
        /// <summary>
        /// Durabilidade
        /// </summary>
        public int Durabilidade { get; private set; }
        /// <summary>
        /// Quantas vezes o brinquedo ja foi utilizado
        /// </summary>
        public int Utilizado { get; private set; }
        /// <summary>
        /// Se o brinquedo ja foi 100% utilizado
        /// </summary>
        public bool Usado { get; private set; }
        /// <summary>
        /// Contrutor de brinquedo
        /// </summary>
        /// <param name="descricao">Descrição do alimento</param>
        /// <param name="preco">Preço do alimento</param>
        /// <param name="potencialDeFelicidade">Potencial de deixar o animal feliz</param>]
        /// <param name="durabilidade">Quantas vezes o produto pode ser utilizado</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref preco="preco"/>, não pode ser menor ou igual a zero</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="potencialDeFelicidade"/>, não pode ser maior que 100 ou menor que -100</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="durabilidade"/>, não pode ser menor ou igual a  zero</exception>
        public Brinquedo(string descricao, double preco, int PotencialDeFelicidade, int durabilidade)
            : base(descricao, preco, PotencialDeFelicidade)
        {
            if(durabilidade <= 0)
            {
                throw new ArgumentException("O brinquedo não pode ter durabilidade menor ou igual a zero");
            }
            this.Durabilidade = durabilidade;
            this.Usado = false;
        }
        /// <summary>
        /// Brinca com o brinquedo
        /// </summary>
        /// <returns>Retorna se foi possivel brincar</returns>
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
    }
}
