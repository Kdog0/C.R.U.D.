using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using prova.models;
using prova.Repositorio.Interface;

namespace prova.Controllers
{   
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAluno _aluno;

        public AlunoController(IAluno aluno)
        {
            _aluno = aluno;
        }

        [HttpPost("aluno/register")]
        public async Task<ActionResult> Cadastro([FromBody] Aluno aluno)
        {
            Aluno _alun = await _aluno.Adcionar(aluno);
            return Ok(_alun);
        }

        [HttpDelete("aluno/delete")]
        public async Task<ActionResult<Aluno>> Deletar(int id)
        {
            bool apagado = await _aluno.AlunoDelete(id);
            return Ok(apagado);
        }

        [HttpGet("aluno/get/all")]
        public async Task<ActionResult<List<Aluno>>> BuscaTodos()
        {
            List<Aluno> alunos = await _aluno.AlunosTodos();
            return Ok(alunos);
        }

        [HttpGet("aluno/get/{id}")]
        public async Task<ActionResult<Aluno>> BuscaPorId(int id)
        {
           Aluno usuario = await _aluno.AlunoId(id);
            return Ok(usuario);
        }

        [HttpPatch("aluno/update/{id}")]
        public async Task<ActionResult<Aluno>> Atulizando([FromBody] Aluno aluno, int id)
        {
            aluno.Id = id;
            Aluno usuario = await _aluno.AlunoUpdate(aluno, id);
            return Ok(usuario);
        }

    }
}
