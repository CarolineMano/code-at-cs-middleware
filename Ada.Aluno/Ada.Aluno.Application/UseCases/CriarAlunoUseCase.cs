using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.UseCases
{
    public class CriarAlunoUseCase : ICriarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public CriarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
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

                _alunoRepository.Add(aluno);

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
