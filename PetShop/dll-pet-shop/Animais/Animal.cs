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
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Felicidade { get; set; }
        public bool Limpo { get; set; }
        public Animal(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode serr nulo ou vazio");
            }
            this.Nome = nome;
            this.Felicidade = 0;
        }
        public Animal()
        {

        }
        public abstract int ReceberComida(Alimento comida);
        public abstract int ReceberBrinquedo(Brinquedo brinquedo);
        public abstract bool TomarBanho();
    }
}
