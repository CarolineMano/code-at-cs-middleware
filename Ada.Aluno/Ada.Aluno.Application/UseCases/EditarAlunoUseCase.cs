using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.UseCases
{
    public class EditarAlunoUseCase : IEditarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public EditarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public ApiResponse Execute(Guid id, CriarAlunoRequest request)
        {
            try
            {
                var aluno = new Core.Aluno(
                    id,
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

                _alunoRepository.Update(aluno);

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
