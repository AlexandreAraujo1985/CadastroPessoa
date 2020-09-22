using CadastroPessoa.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Data.Context
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions<CadastroPessoaContext> options)
            : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
