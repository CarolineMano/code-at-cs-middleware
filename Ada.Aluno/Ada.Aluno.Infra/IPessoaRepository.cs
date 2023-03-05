using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Infra
{
    public interface IPessoaRepository
    {
        void Add(Core.Aluno aluno);

        void Delete(Guid id);

        void Update(Core.Aluno aluno);
        Core.Aluno GetById(Guid id);
    }
}
