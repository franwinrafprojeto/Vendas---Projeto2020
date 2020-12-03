using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Entrega
    {
        public int Id { get; set; }

        public int id_Cliente { get; set; }

        public int id_Entregador { get; set; }

        public int id_Endereco { get; set; }
    }
}
