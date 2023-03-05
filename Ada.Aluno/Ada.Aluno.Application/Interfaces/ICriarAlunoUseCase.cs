using Ada.Aluno.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Interfaces
{
    public interface ICriarAlunoUseCase
    {
        ApiResponse Execute(CriarAlunoRequest request);
    }
}
