using Ada.Aluno.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        void Add(Core.Aluno aluno);
        void Delete(Guid id);
        void Update(Core.Aluno aluno);
        Core.Aluno GetById(Guid id);
        IEnumerable<Core.Aluno> GetAll(ListarAlunoPorNomeECidadeRequest request);
    }
}
