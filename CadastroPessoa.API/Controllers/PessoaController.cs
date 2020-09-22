using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroPessoa.Data.Entity;
using CadastroPessoa.Data.Repository;
using static CadastroPessoa.API.ValidarDados;

namespace CadastroPessoa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        public readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPessoa(int id)
        {
            var pessoa = await _pessoaRepository.ObterPessoa(id);

            return Ok(pessoa);
        }

        [HttpGet]
        public async Task<IActionResult> ListarPessoas(string nome = null, string cpf = null, DateTime data = default,
            string pais = null, string estado = null, string cidade = null)
        {
            var pessoas = await _pessoaRepository.ListarPessoas(nome, cpf, data, pais, estado, cidade);

            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                ValidarPessoa(pessoa);

                await _pessoaRepository.IncluirPessoa(pessoa);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"O campo {ex.Message} é obrigatório");
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarPessoa([FromBody] Pessoa pessoa)
        {
            await _pessoaRepository.IncluirPessoa(pessoa);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirPessoa([FromBody] Pessoa pessoa)
        {
            await _pessoaRepository.IncluirPessoa(pessoa);
            return Ok();
        }
    }
}
