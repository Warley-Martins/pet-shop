using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Animais
{
    /// <summary>
    /// Classe que representa um cachorro
    /// </summary>
    public class Cachorro : Animal
    {
        public Cachorro(string nome)
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
            if(comida == null)
            {
                throw new NullReferenceException("O alimento não posseui referencia definida");
            }
            if(comida.Usado == true)
            {
                this.Felicidade -= 10;
                return this.Felicidade;
            }
            return this.Felicidade += comida.PotencialDeFelicidade;
        }
        /// <summary>
        /// Recebe um brinquedo do dono
        /// </summary>
        /// <param name="comida">Alimento recebido</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="brinquedo"/>, não possui referência definida</exception>
        /// <returns>Retorna o grau de felidade atualizado</returns>
        public override int ReceberBrinquedo(Brinquedo brinquedo)
        {
            if(brinquedo == null)
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
    }
}
