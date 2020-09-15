using System;

namespace dll_pet_shop
{
    /// <summary>
    /// Cliente do pet shop
    /// </summary>
    public class Cliente : Pessoa
    {
        /// <summary>
        /// Animal do cliente
        /// </summary>
        public Animal Animal { get; set; }
        /// <summary>
        /// Construtor do cliente
        /// </summary> 
        /// <param name="nome">Nome do cliente</param>
        /// <param name="cpf">Cpf da cliente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        public Cliente(string nome, string cpf)
            : base(nome, cpf)
        {

        }
    }
}
