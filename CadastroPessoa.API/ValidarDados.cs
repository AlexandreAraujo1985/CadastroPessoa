using System;
using static System.String;
using CadastroPessoa.Data.Entity;

namespace CadastroPessoa.API
{
    public class ValidarDados
    {
        public static void ValidarPessoa(Pessoa pessoa)
        {
            Validar(it => it.Nome, pessoa).ValidarTexto(nameof(pessoa.Nome));

            Validar(it => it.CPF, pessoa).ValidarTexto(nameof(pessoa.CPF));

            Validar(it => it.DataNascimento, pessoa).ValidarTexto(nameof(pessoa.DataNascimento));

            Validar(it => it.PaisNascimento, pessoa).ValidarTexto(nameof(pessoa.PaisNascimento));

            Validar(it => it.EstadoNascimento, pessoa).ValidarTexto(nameof(pessoa.EstadoNascimento));

            Validar(it => it.CidadeNascimento, pessoa).ValidarTexto(nameof(pessoa.CidadeNascimento));

            Validar(it => it.Email, pessoa).ValidarTexto(nameof(pessoa.Email));

        }

        public static object Validar(Func<Pessoa, object> action, Pessoa pessoa)
        {
            var valor = action(pessoa);
            return valor;
        }
    }

    public static class Extensions
    {
        internal static void Guard(this object obj, string message, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        internal static void ValidarTexto(this object valor, string propriedade)
        {
            if (IsNullOrEmpty(valor.ToString()))
                throw new ArgumentException($"{propriedade}");
        }
    }
}