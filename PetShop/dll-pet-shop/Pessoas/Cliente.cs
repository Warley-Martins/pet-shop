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
        public int Id { get; }
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
        /// <exception cref="NullReferenceException">O parametro: <paramref name="animal"/>, não pode ser nulo</exception>
        public Cliente(string nome, string cpf, Animal animal)
            : base(nome, cpf)
        {
            if(animal == null)
            {
                throw new NullReferenceException("O cliente não pode ser cadastrado sem um pet");
            }
            this.ProdutosAlimentos = new List<Alimento>();
            this.ProdutosBrinquedos = new List<Brinquedo>();
            this.Animal = animal;
        }
        /// <summary>
        /// Alimentos para o pet do cliente
        /// </summary>
        public List<Alimento> ProdutosAlimentos { get; set; }
        /// <summary>
        /// Brinquedos para o pet do cliente
        /// </summary>
        public List<Brinquedo> ProdutosBrinquedos { get; set; }
        public void ComprarComidaParaAnimal(params Alimento[] alimentos)
        {
            if (alimentos == null)
            {
                throw new NullReferenceException("Referencia não definida para alimentos comprados");
            }
            foreach (var item in alimentos)
            {
                this.ProdutosAlimentos.Add(item);
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
                this.ProdutosBrinquedos.Add(item);
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
            this.ProdutosAlimentos.Remove(alimento);
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
            this.ProdutosBrinquedos.Remove(brinquedo);
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
            return this.ProdutosBrinquedos
                       .Where(x => x.Descricao == descricao)
                       .FirstOrDefault();
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
            return this.ProdutosAlimentos
                       .Where(x => x.Descricao == descricao)
                       .FirstOrDefault();
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
            return this.Animal.ReceberBrinquedo(brinquedo);
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
            return this.Animal.ReceberComida(alimento);
        }


    }
}
