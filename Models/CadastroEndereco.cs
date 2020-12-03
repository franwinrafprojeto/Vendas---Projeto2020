using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class CadastroEndereco
    {

        
        public int ID { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string NumeroCasa { get; set; }
        public string StatusEntrega { get; set; }
    }
}
