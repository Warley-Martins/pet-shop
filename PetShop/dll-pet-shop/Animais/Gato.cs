using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Animais
{
    /// <summary>
    /// Classe que representa um gato
    /// </summary>
    public class Gato : Animal
    {
        public int Id { get; }
        public Cliente Dono { get; set; }
        public Gato(string nome)
            : base(nome)
        {

        }
        /// <summary>
        /// Recebe um alimento do dono
        /// </summary>
        /// <param name="comida">Alimento recebido</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="comida"/>, não possui referência definida</exception>
        /// <returns>Retorna o grau de felidade atualizado</returns>
        public override int ReceberComida(Alimento comida)
        {
            if (comida == null)
            {
                throw new NullReferenceException("O alimento não posseui referencia definida");
            }
            if (comida.Usado == true)
            {
                if (Felicidade <= -90)
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
        }        /// <summary>
                 /// Recebe um brinquedo do dono
                 /// </summary>
                 /// <param name="comida">Alimento recebido</param>
                 /// <exception cref="NullReferenceException">O parametro: <paramref name="brinquedo"/>, não possui referência definida</exception>
                 /// <returns>Retorna o grau de felidade atualizado</returns>
        public override int ReceberBrinquedo(Brinquedo brinquedo)
        {
            if (brinquedo == null)
            {
                throw new NullReferenceException("O brinquedo não possui referencia definida");
            }
            return this.Felicidade += brinquedo.PotencialDeFelicidade;
        }
        /// <summary>
        /// Toma um banho
        /// </summary>
        public override bool TomarBanho()
        {
            this.Limpo = true;
            return this.Limpo;
        }

        public int Brincar(Brinquedo brinquedo)
        {
            if (brinquedo == null)
            {
                throw new NullReferenceException("Referencia não definida para brinquedo");
            }
            if (brinquedo.Usado == true)
            {
                if (ConfereFelicidade(brinquedo))
                {
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
            if (produto.PotencialDeFelicidade + this.Felicidade > 100)
            {
                this.Felicidade = 100;
                return false;
            }
            if (produto.PotencialDeFelicidade > 0)
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
