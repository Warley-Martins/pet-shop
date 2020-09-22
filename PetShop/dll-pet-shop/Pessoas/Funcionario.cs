using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Pessoas
{
    /// <summary>
    /// Funcionario do pet shop
    /// </summary>
    public class Funcionario : Pessoa
    {
        /// <summary>
        /// Construtor do funcionario
        /// </summary>
        /// <param name="nome">Nome do funcionario</param>
        /// <param name="cpf">Cpf do funcionario</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        public Funcionario(string nome, string cpf)
            : base(nome, cpf)
        {

        }
        /// <summary>
        /// Construtor default
        /// </summary>
        public Funcionario()
            : base()
        {

        }
    }
}
