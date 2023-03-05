using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Requests;
using Ada.Aluno.Infra;

namespace Ada.Aluno.Application.UseCases
{
    public class CriarAlunoUseCase : ICriarAlunoUseCase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public CriarAlunoUseCase(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public ApiResponse Execute(CriarAlunoRequest request)
        {
            try
            {
                var aluno = new Core.Aluno(
                    request.Nome,
                    request.Cidade,
                    request.NomeMae);

                if (!aluno.IsValid)
                {
                    return new ApiResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.Conflict,
                        Messages = aluno.Messages
                    };
                }

                _pessoaRepository.Add(aluno);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Data = aluno
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Messages = new List<string> { ex.Message}
                };
            }
        }
    }
}
