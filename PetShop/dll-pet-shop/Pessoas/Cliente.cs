using dll_pet_shop.Animais;
using dll_pet_shop.Join;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dll_pet_shop
{
    public class Cliente : Pessoa
    {
        public Cachorro Cachorro { get; set; }
        public Gato Gato { get; set; }
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
        public Cliente()
            : base()
        {
            this.ProdutosAlimentos = new List<ClienteAlimento>();
            this.ProdutosBrinquedos = new List<ClienteBrinquedo>();
        }
        public List<ClienteAlimento> ProdutosAlimentos { get; set; }
        public List<ClienteBrinquedo> ProdutosBrinquedos { get; set; }
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
