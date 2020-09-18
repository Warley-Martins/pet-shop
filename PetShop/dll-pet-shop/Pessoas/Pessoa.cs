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
        /// Nome da pessoa
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF da pessoa
        /// </summary>
        public string CPF { get; set; }
        public List<Alimento> ProdutosAlimentos { get; set; }
        public List<Brinquedo> ProdutosBrinquedos { get; set; }
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
            this.ProdutosAlimentos = new List<Alimento>();
            this.ProdutosBrinquedos = new List<Brinquedo>();
        }
        /// <summary>
        /// Compra alimentos para seu pet
        /// </summary>
        /// <param name="alimentos">Array de alimentos com capacidade livre</param>
        /// <exception cref="NullReferenceException">O parametro: <paramref name="alimentos"/>, não possui referencia definida</exception>
        public void ComprarComidaParaAnimal(params Alimento[] alimentos)
        {
            if(alimentos == null)
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
        public void DescartarAlimento(Alimento alimento)
        {
            if(alimento == null)
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
        public void DescartarBrinquedo(Brinquedo brinquedo)
        {
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

    }
}
