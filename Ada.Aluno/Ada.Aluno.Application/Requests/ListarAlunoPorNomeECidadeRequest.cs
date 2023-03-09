using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.Requests
{
    public class ListarAlunoPorNomeECidadeRequest
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
    }
}
