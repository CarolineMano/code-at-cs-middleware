using Ada.Aluno.Application.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Mapper
{
    public static class ListaOutputMap
    {
        public static ListarAlunosOutput Mapear(Core.Aluno aluno)
        {
            return new ListarAlunosOutput()
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cidade = aluno.Cidade
            };
        }
    }
}
