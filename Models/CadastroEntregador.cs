using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class CadastroEntregador
    {
        public int Id { get; set; }

        public string Nome_Entregador { get; set; }

        public int Telefone_Entregador { get; set; }

        private int CPF_Entregador { get; set; }

        public int GetRG_Entregador { get; set; }

        public int Habilitação_Entregador { get; set; }
    }
}
