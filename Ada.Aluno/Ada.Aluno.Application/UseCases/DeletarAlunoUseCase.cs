using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.Interfaces.UseCases;

namespace Ada.Aluno.Application.UseCases
{
    public class DeletarAlunoUseCase : IDeletarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public DeletarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public ApiResponse Execute(Guid id)
        {
            try
            {
                _alunoRepository.Delete(id);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK
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
