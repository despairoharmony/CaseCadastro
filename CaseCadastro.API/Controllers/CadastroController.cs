using CaseCadastro.Application.Interfaces;
using CaseCadastro.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseCadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        public readonly ICadastroService _cadastroService;
        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cadastroList = await _cadastroService.GetAll();

            if (cadastroList == null)
            {
                return NotFound();
            }

            return Ok(cadastroList);
        }

        [HttpGet("{idCadastro}")]
        public async Task<IActionResult> GetById(int idCadastro)
        {
            var cadastrodetalhe = await _cadastroService.GetById(idCadastro);

            if (cadastrodetalhe != null)
            {
                return Ok(cadastrodetalhe);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Cadastro cliente)
        {
            var isDone = await _cadastroService.InserirCadastro(cliente);

            if (isDone)
            {
                return Ok(isDone);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cadastro cliente)
        {
            if (cliente != null)
            {
                var isDone = await _cadastroService.UpdateCadastro(cliente);
                if (isDone)
                {
                    return Ok(isDone);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idCadastro}")]
        public async Task<IActionResult> Delete(int idCadastro)
        {
            var isDone = await _cadastroService.DeleteCadastro(idCadastro);

            if (isDone)
            {
                return Ok(isDone);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
