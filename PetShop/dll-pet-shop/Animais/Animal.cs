using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    /// <summary>
    /// Animal
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// Id do animal
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do animal
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// grau de felicidade do animal
        /// </summary>
        public int Felicidade { get; set; }
        /// <summary>
        /// Se o animal esta limpo
        /// </summary>
        public bool Limpo { get; set; }
        /// <summary>
        /// Construtor do animal
        /// </summary>
        /// <param name="nome">Nome do animal</param>
        public Animal(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode serr nulo ou vazio");
            }
            this.Nome = nome;
            this.Felicidade = 0;
        }
        /// <summary>
        /// Construtor default de animal
        /// </summary>
        public Animal()
        {

        }
        /// <summary>
        /// Recebe um alimento do dono
        /// </summary>
        /// <param name="comida">Alimento recebido</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="comida"/>, não possui referência definida</exception>
        /// <returns>Retorna o grau de felidade atualizado</returns>
        public abstract int ReceberComida(Alimento comida);
        /// <summary>
        /// Recebe um brinquedo do dono
        /// </summary>
        /// <param name="comida">Alimento recebido</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="brinquedo"/>, não possui referência definida</exception>
        /// <returns>Retorna o grau de felidade atualizado</returns>
        public abstract int ReceberBrinquedo(Brinquedo brinquedo);
        /// <summary>
        /// Toma um banho
        /// </summary>
        public abstract bool TomarBanho();
    }
}
