using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ada.Api.Presentation.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly ICriarAlunoUseCase _criarAlunoUseCase;

        public PessoasController(ICriarAlunoUseCase criarAlunoUseCase)
        {
            _criarAlunoUseCase = criarAlunoUseCase;
        }
        // GET: api/<AlunosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlunosController>
        [HttpPost]
        public IActionResult Post([FromBody] CriarAlunoRequest request)
        {
            var response = _criarAlunoUseCase.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return StatusCode((int)response.StatusCode, response.Data);

            return StatusCode((int)response.StatusCode, response.Messages);
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
