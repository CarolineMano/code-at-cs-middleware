using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Interfaces.UseCases
{
    public interface ListarAlunosPorNomeECidadeRequest
    {
        ApiResponse Execute(Guid id);
    }
}
