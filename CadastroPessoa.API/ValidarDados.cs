using CadastroPessoa.Data.Entity;
using System;
using static System.String;

namespace CadastroPessoa.API
{
    public class ValidarDados
    {
        public static void ValidarPessoa(Pessoa pessoa)
        {
            if (IsNullOrEmpty(pessoa.Nome))
                throw new ArgumentException(nameof(pessoa.Nome));

            if (IsNullOrEmpty(pessoa.CPF))
                throw new ArgumentException(nameof(pessoa.CPF));

            if (pessoa.DataNascimento == default)
                throw new ArgumentException(nameof(pessoa.DataNascimento));

            if (IsNullOrEmpty(pessoa.PaisNascimento))
                throw new ArgumentException(nameof(pessoa.PaisNascimento));

            if (IsNullOrEmpty(pessoa.EstadoNascimento))
                throw new ArgumentException(nameof(pessoa.EstadoNascimento));

            if (IsNullOrEmpty(pessoa.CidadeNascimento))
                throw new ArgumentException(nameof(pessoa.CidadeNascimento));

            if (IsNullOrEmpty(pessoa.Email))
                throw new ArgumentException(nameof(pessoa.Email));
        }
    }
}
