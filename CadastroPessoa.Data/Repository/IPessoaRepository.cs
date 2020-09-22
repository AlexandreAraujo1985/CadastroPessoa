using CadastroPessoa.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.Data.Repository
{
    public interface IPessoaRepository
    {
        Task<Pessoa> ObterPessoa(int id);
        Task<IEnumerable<Pessoa>> ListarPessoas(string nome = null, string cpf = null, DateTime data = default, 
            string pais = null, string estado = null, string cidade = null);
        Task IncluirPessoa(Pessoa pessoa);
        Task AtualizarPessoa(Pessoa pessoa);
        Task ExcluirPessoa(Pessoa pessoa);
    }
}
