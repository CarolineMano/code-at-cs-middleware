using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.UseCases
{
    public class CriarAlunoUseCase : ICriarAlunoUseCase
    {
        public CriarAlunoUseCase()
        {

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
