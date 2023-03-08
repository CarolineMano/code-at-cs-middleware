using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;
using Ada.Aluno.Application.Mapper;

namespace Ada.Aluno.Application.UseCases
{
    public class ListarAlunosUseCase : IListarAlunosUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public ListarAlunosUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public ApiResponse Execute()
        {
            try
            {
                var alunos = _alunoRepository.GetAll();
                var alunosDto = alunos.Select(p => ListaOutputMap.Mapear(p)).ToList();


                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = alunosDto
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Messages = new List<string> { ex.Message }
                };
            }
        }
    }
}
