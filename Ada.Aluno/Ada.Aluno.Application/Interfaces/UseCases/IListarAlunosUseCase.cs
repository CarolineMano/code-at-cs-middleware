using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.Interfaces.UseCases
{
    public interface IListarAlunosUseCase
    {
        ApiResponse Execute(ListarAlunoPorNomeECidadeRequest request);
    }
}
