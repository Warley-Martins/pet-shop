using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Join
{
    public class ClienteAlimento
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int AlimentoId { get; set; }
        public Alimento Alimento { get; set; }
    }
}
