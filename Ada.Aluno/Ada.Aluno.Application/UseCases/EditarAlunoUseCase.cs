using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.Mapper;
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
                var alunoDb = _alunoRepository.GetById(id);
                var aluno = new Core.Aluno(
                    id,
                    request.Nome is null ? alunoDb.Nome : request.Nome,
                    request.Cidade is null ? alunoDb.Cidade : request.Cidade,
                    request.NomeMae is null ? alunoDb.NomeMae : request.NomeMae);

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
                    Data = ListaOutputMap.Mapear(aluno)
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
