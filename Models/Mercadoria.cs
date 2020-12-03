using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Mercadoria
    {
        public int Id { get; set; }
        public int Peso { get; set; }
        public string Tipo_Mercadoria { get; set; }
        public int Quantidade_Mercadoria { get; set; }
        public string Nome_Mercadoria { get; set; }
    }
}
