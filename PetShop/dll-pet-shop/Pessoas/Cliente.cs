using dll_pet_shop.Animais;
using dll_pet_shop.Join;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dll_pet_shop
{
    /// <summary>
    /// Cliente do pet shop
    /// </summary>
    public class Cliente : Pessoa
    {
        /// <summary>
        /// Cachorro do cliente
        /// </summary>
        public Cachorro Cachorro { get; set; }
        public Gato Gato { get; set; }
        /// <summary>
        /// Construtor do cliente
        /// </summary> 
        /// <param name="nome">Nome do cliente</param>
        /// <param name="cpf">Cpf da cliente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="animal"/>, não pode ser nulo</exception>
        public Cliente(string nome, string cpf, Animal animal)
            : base(nome, cpf)
        {
            if(animal == null)
            {
                throw new NullReferenceException("O cliente não pode ser cadastrado sem um pet");
            }
            this.ProdutosAlimentos = new List<ClienteAlimento>();
            this.ProdutosBrinquedos = new List<ClienteBrinquedo>();
            var gato = animal as Gato;
            if(gato != null)
            {
                this.Gato = gato;
            }
            else
            {
                var cachorro = animal as Cachorro;
                this.Cachorro = cachorro;
            }
        }
        /// <summary>
        /// Construtor default de cliente
        /// </summary>
        public Cliente()
            : base()
        {
            this.ProdutosAlimentos = new List<ClienteAlimento>();
            this.ProdutosBrinquedos = new List<ClienteBrinquedo>();
        }
        /// <summary>
        /// Alimentos para o pet do cliente
        /// </summary>
        public List<ClienteAlimento> ProdutosAlimentos { get; set; }
        /// <summary>
        /// Brinquedos para o pet do cliente
        /// </summary>
        public List<ClienteBrinquedo> ProdutosBrinquedos { get; set; }
        /// <summary>
        /// Compra alimentos para seu pet
        /// </summary>
        /// <param name="alimentos">Array de alimentos com capacidade livre</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="alimentos]"/>, não possui referencia definida</exception>
        public void ComprarComidaParaAnimal(params Alimento[] alimentos)
        {
            if (alimentos == null)
            {
                throw new NullReferenceException("Referencia não definida para alimentos comprados");
            }
            foreach (var item in alimentos)
            {
                this.ProdutosAlimentos.Add(new ClienteAlimento{ Alimento = item });
            }
        }
        /// <summary>
        /// Compra alimentos para seu pet
        /// </summary>
        /// <param name="brinquedos">Array de brinquedos com capacidade livre</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="brinquedos"/>, não possui referencia definida</exception>
        public void ComprarBrinquedoParaAnimal(params Brinquedo[] brinquedos)
        {
            if (brinquedos == null)
            {
                throw new NullReferenceException("Referencia não definida para brinquedos comprados");
            }
            foreach (var item in brinquedos)
            {
                this.ProdutosBrinquedos.Add(new ClienteBrinquedo { Brinquedo = item });
            }
        }
        /// <summary>
        /// Descarta um alimento
        /// </summary>
        /// <param name="alimento">Alimento descartado</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="alimento"/>, não pode ser nulo</exception>
        public void DescartarAlimento(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new NullReferenceException("A descrição do alimento dado não pode ser nulo");
            }
            var alimento = ProcuraAlimento(descricao);
            if (alimento == null)
            {
                throw new NullReferenceException("O alimento descartado não pode ser nulo");
            }
            var alimentoRemovido = new ClienteAlimento() { Alimento = alimento };
            this.ProdutosAlimentos.Remove(alimentoRemovido);
        }
        /// <summary>
        /// Descarta um brinquedo
        /// </summary>
        /// <param name="brinquedo">Brinquedo descartado</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="brinquedo"/>, não pode ser nulo</exception>
        public void DescartarBrinquedo(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new NullReferenceException("A descrição do brinquedo dado não pode ser nulo");
            }
            var brinquedo = ProcuraBrinquedo(descricao);
            if (brinquedo == null)
            {
                throw new NullReferenceException("O brinquedo descartado não pode ser nulo");
            }
            var brinquedoRemovido = new ClienteBrinquedo() { Brinquedo = brinquedo};
            this.ProdutosBrinquedos.Remove(brinquedoRemovido);
        }
        /// <summary>
        /// Procura um brinqudo 
        /// </summary>
        /// <param name="descricao">Descrição do brinquedo procurado</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo ou vazio</exception>
        /// <returns>Retorna o brinqueo se achado</returns>
        public Brinquedo ProcuraBrinquedo(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("A descrição do brinquedo não pode ser nula ou vazia");
            }
            var brinquedo =  this.ProdutosBrinquedos
                            .Where(x => x.Brinquedo.Descricao == descricao)
                            .FirstOrDefault();
            return brinquedo.Brinquedo;
        }
        /// <summary>
        /// Procura um alimento 
        /// </summary>
        /// <param name="descricao">Descrição do alimento procurado</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo ou vazio</exception>
        /// <returns>Retorna o alimento se achado</returns>
        public Alimento ProcuraAlimento(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("A descrição do alimento não pode ser nula ou vazia");
            }
            var alimento = this.ProdutosAlimentos
                           .Where(x => x.Alimento.Descricao == descricao)
                           .FirstOrDefault();
            return alimento.Alimento;
        }
        /// <summary>
        /// Dar um brinquedo ao pet
        /// </summary>
        /// <param name="brinquedo">Descrição do brinquedo dado</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo</exception>
        /// <exception cref="NullReferenceException">Caso o cliente não possua o brinquedo procurado</exception>
        /// <returns>Retorna a felicidade do pet ao receber o brinquedo</returns>
        public int DarBrinquedoAoPet(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new NullReferenceException("A descrição do brinquedo dado não pode ser nulo");
            }
            var brinquedo = ProcuraBrinquedo(descricao);
            if(brinquedo == null)
            {
                throw new NullReferenceException("O cliente não possui o brinquedo procurado");
            }
            if(this.Gato == null && this.Cachorro == null)
            {
                throw new NullReferenceException("O cliente não possui um pet");
            }
            if(this.Gato != null)
            {
                return this.Gato.ReceberBrinquedo(brinquedo);
            }
            return this.Cachorro.ReceberBrinquedo(brinquedo);
        }
        /// <summary>
        /// Dar um alimento ao pet
        /// </summary>
        /// <param name="descricao">Descrição do alimentodado</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="descricao"/>, não pode ser nulo</exception>
        /// <exception cref="NullReferenceException">Caso o cliente não possua o alimento procurado</exception>
        /// <returns>Retorna a felicidade do pet ao receber o alimetno</returns>
        public int DarAlimentoAoPet(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                throw new NullReferenceException("A descrição do alimento dado não pode ser nulo");
            }
            var alimento = ProcuraAlimento(descricao);
            if (alimento == null)
            {
                throw new NullReferenceException("O cliente não possui o brinquedo procurado");
            }

            if (this.Gato == null && this.Cachorro == null)
            {
                throw new NullReferenceException("O cliente não possui um pet");
            }
            if (this.Gato != null)
            {
                return this.Gato.ReceberComida(alimento);
            }
            return this.Cachorro.ReceberComida(alimento);
        }
        public bool LevarPetParaTomarBanho()
        {

            if (this.Gato == null && this.Cachorro == null)
            {
                throw new NullReferenceException("O cliente não possui um pet");
            }
            if (this.Gato != null)
            {
                return this.Gato.TomarBanho();
            }
            return this.Cachorro.TomarBanho();
        }


    }
}
