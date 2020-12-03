using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Models;

namespace Vendas.Data
{
    public class VendasContext : DbContext
    {
        public VendasContext (DbContextOptions<VendasContext> options)
            : base(options)
        {
        }

        public DbSet<Vendas.Models.CadastroEndereco> CadastroEndereco { get; set; }

        public DbSet<Vendas.Models.CadastroEntregador> CadastroEntregador { get; set; }

        public DbSet<Vendas.Models.CadastroPagamento> CadastroPagamento { get; set; }

        public DbSet<Vendas.Models.CadastroPessoal> CadastroPessoal { get; set; }

        public DbSet<Vendas.Models.Entrega> Entrega { get; set; }

        public DbSet<Vendas.Models.Mercadoria> Mercadoria { get; set; }
    }
}
