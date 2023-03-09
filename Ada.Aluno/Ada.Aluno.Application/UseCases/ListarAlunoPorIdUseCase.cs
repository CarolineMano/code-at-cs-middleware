using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.Mapper;

namespace Ada.Aluno.Application.UseCases
{
    public class ListarAlunoPorIdUseCase : ListarAlunosPorNomeECidadeRequest
    {
        private readonly IAlunoRepository _alunoRepository;
        public ListarAlunoPorIdUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public ApiResponse Execute(Guid id)
        {
            try
            {
                var aluno = _alunoRepository.GetById(id);

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
