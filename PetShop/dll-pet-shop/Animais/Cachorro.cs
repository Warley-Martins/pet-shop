using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Animais
{
    public class Cachorro : Animal
    {
        public Cachorro()
        {

        }
        public Cachorro(string nome)
            : base(nome)
        {

        }
        public override int ReceberComida(Alimento comida)
        {
            if(comida == null)
            {
                throw new NullReferenceException("O alimento não possui referencia definida");
            }
            if(comida.Usado == true)
            {
                if(Felicidade <= -90)
                {
                    return this.Felicidade = -100;
                }
                return this.Felicidade -= 10;
            }
            if (ConfereFelicidade(comida))
            {
                this.Felicidade += comida.PotencialDeFelicidade;
            }
            comida.Comer();
            return this.Felicidade;
        }
        public override int ReceberBrinquedo(Brinquedo brinquedo)
        {
            if(brinquedo == null)
            {
                throw new NullReferenceException("O brinquedo não possui referencia definida");
            }
            return this.Felicidade += brinquedo.PotencialDeFelicidade;
        }
        public override bool TomarBanho()
        {
            this.Limpo = true;
            return this.Limpo;
        }
        public int Brincar(Brinquedo brinquedo)
        {
            if(brinquedo == null)
            {
                throw new NullReferenceException("Referencia não definida para brinquedo");
            } 
            if(brinquedo.Usado == true)
            {
                if (ConfereFelicidade(brinquedo)) {
                    return this.Felicidade -= brinquedo.PotencialDeFelicidade;
                }
            }
            brinquedo.UtilizarBrinquedo();
            if (ConfereFelicidade(brinquedo))
            {
                return this.Felicidade += brinquedo.PotencialDeFelicidade;
            }
            return this.Felicidade;
        }
        private bool ConfereFelicidade(Produto produto)
        {
            int sinal = 1;
            if(produto.PotencialDeFelicidade + this.Felicidade > 100)
            {
                this.Felicidade = 100;
                return false;
            }
            if(produto.PotencialDeFelicidade > 0)
            {
                sinal = -1;
            }
            if ((produto.PotencialDeFelicidade * sinal) + this.Felicidade < -100)
            {
                this.Felicidade = -100;
                return false;
            }
            return true;
        }
    }
}
