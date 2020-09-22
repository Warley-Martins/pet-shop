using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Pessoas
{
    public class Funcionario : Pessoa
    {
        public Funcionario(string nome, string cpf)
            : base(nome, cpf)
        {

        }
        public Funcionario()
            : base()
        {

        }
    }
}
