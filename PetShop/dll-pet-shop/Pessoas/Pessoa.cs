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
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
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
        public Pessoa()
        {

        }
    }
}
