using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Output
{
    public class ListarAlunosOutput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string? NomeMae { get; set; }
    }
}
