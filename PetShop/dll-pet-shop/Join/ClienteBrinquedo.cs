using System;
using System.Collections.Generic;
using System.Text;

namespace dll_pet_shop.Join
{
    public class ClienteBrinquedo
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int BrinquedoId { get; set; }
        public Brinquedo Brinquedo { get; set; }
    }
}
