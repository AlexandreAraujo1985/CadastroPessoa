using System;
using System.Linq;
using System.Threading.Tasks;
using CadastroPessoa.Data.Entity;
using System.Collections.Generic;
using CadastroPessoa.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly CadastroPessoaContext _db;
        public PessoaRepository(CadastroPessoaContext db)
        {
            _db = db;
        }

        public async Task AtualizarPessoa(Pessoa pessoa)
        {
            _db.Entry(pessoa).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task ExcluirPessoa(Pessoa pessoa)
        {
            _db.Set<Pessoa>().Remove(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task IncluirPessoa(Pessoa pessoa)
        {
            _db.Set<Pessoa>().Add(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> ListarPessoas(string nome = null, string cpf = null, DateTime data = default,
           string pais = null, string estado = null, string cidade = null) =>
           await _db.Set<Pessoa>()
                .Where(it =>
                    it.Nome == nome || it.CPF == cpf || it.DataNascimento == data || it.PaisNascimento == pais || it.EstadoNascimento == estado || it.CidadeNascimento == cidade)
                .ToListAsync();

        public async Task<Pessoa> ObterPessoa(int id) =>
           await _db.Set<Pessoa>().FindAsync(id);
    }
}
