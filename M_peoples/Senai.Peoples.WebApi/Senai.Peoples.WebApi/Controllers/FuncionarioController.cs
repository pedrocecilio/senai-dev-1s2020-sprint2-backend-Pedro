using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private IFuncionarioRepository _funcionarioRepository { get; set; }


        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]

        public IEnumerable<FuncionarioDomain> List()
        {
            return _funcionarioRepository.List();
        }

        [HttpGet("{id}")]
        public IActionResult SearchId(int id)
        {
            FuncionarioDomain funcionarioWanted = _funcionarioRepository.SearchId(id);

            if (funcionarioWanted == null)
            {

                return NotFound("Funcionário não encontrado");
            }

            return Ok(funcionarioWanted);
        }

        [HttpPost]
        public IActionResult Insert(FuncionarioDomain newFuncionario)
        {

            _funcionarioRepository.Insert(newFuncionario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIdUrl(int id, FuncionarioDomain funcionarioUpadated)
        {

            FuncionarioDomain funcionarioWanted = _funcionarioRepository.SearchId(id);

            if (funcionarioWanted == null)
            {

                return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",

                    }
                );
            }
            try
            {

                _funcionarioRepository.UpdateIdUrl(id, funcionarioUpadated);

                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }


            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.Delete(id);

            return Ok("Funcionário Deletado.");
        }


    }
}