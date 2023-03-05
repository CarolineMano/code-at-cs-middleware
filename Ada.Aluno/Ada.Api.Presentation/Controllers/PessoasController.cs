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
        private readonly IDeletarAlunoUseCase _deletarAlunoUseCase;
        private readonly IEditarAlunoUseCase _editarAlunoUseCase;
        private readonly IListarAlunoPorIdUseCase _listarAlunoPorIdUseCase;

        public PessoasController(ICriarAlunoUseCase criarAlunoUseCase, IDeletarAlunoUseCase deletarAlunoUseCase, IEditarAlunoUseCase editarAlunoUseCase, IListarAlunoPorIdUseCase listarAlunoPorIdUseCase)
        {
            _criarAlunoUseCase = criarAlunoUseCase;
            _deletarAlunoUseCase = deletarAlunoUseCase;
            _editarAlunoUseCase = editarAlunoUseCase;
            _listarAlunoPorIdUseCase = listarAlunoPorIdUseCase;
        }
        // GET: api/<AlunosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var response = _listarAlunoPorIdUseCase.Execute(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return StatusCode((int)response.StatusCode, response.Data);

            return StatusCode((int)response.StatusCode, response.Messages);
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
        public IActionResult Put(Guid id, CriarAlunoRequest request)
        {
            var response = _editarAlunoUseCase.Execute(id, request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return StatusCode((int)response.StatusCode, response.Data);

            return StatusCode((int)response.StatusCode, response.Messages);
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = _deletarAlunoUseCase.Execute(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return StatusCode((int)response.StatusCode);

            return StatusCode((int)response.StatusCode, response.Messages);
        }
    }
}
