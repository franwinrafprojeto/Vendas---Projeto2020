using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vendas.Models
{
    public class CadastroPessoal
    {
        public int Id { get; set; }

        
        public string Nome_Sobrenome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public int Data_Nascimento { get; set; }
    }
}
