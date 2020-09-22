using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop
{
    /// <summary>
    /// Pessoa
    /// </summary>
    public abstract class Pessoa
    {
        /// <summary>
        /// Id da pessoa
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF da pessoa
        /// </summary>
        public string CPF { get; set; }
        /// <summary>
        /// Construtor de pessoa
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        /// <param name="cpf">Cpf da pessoa</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        public Pessoa(string nome, string cpf)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio");
            }
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nulo ou vazio");
            }
            this.CPF = cpf;
            this.Nome = nome;
        }
        /// <summary>
        /// Construtor default de pessoa
        /// </summary>
        public Pessoa()
        {

        }
    }
}
