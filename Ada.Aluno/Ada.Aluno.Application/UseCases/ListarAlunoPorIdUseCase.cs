using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Infra;

namespace Ada.Aluno.Application.UseCases
{
    public class ListarAlunoPorIdUseCase : IListarAlunoPorIdUseCase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public ListarAlunoPorIdUseCase(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public ApiResponse Execute(Guid id)
        {
            try
            {
                var aluno = _pessoaRepository.GetById(id);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = aluno
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Messages = new List<string> { ex.Message }
                };
            }
        }
    }
}
