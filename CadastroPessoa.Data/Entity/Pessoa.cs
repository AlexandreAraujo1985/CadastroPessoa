using System;

namespace CadastroPessoa.Data.Entity
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PaisNascimento { get; set; }
        public string EstadoNascimento { get; set; }
        public string CidadeNascimento { get; set; }
        public string NomePai { get; set; }
        public string NomeMãe { get; set; }
        public string Email { get; set; }
    }
}
