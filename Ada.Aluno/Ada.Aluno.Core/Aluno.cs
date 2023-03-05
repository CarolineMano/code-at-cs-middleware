using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Core
{
    public class Aluno : BaseEntity
    {
        public Aluno(string nome, string cidade, string? nomeMae) : base()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cidade = cidade;
            NomeMae = nomeMae;
            Validate();
        }

        public Aluno(Guid id, string nome, string cidade, string? nomeMae) : base()
        {
            Id = id;
            Nome = nome;
            Cidade = cidade;
            NomeMae = nomeMae;
            Validate();
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cidade { get; private set; }
        public string? NomeMae { get; private set; }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                Messages.Add("O nome deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(Cidade))
                Messages.Add("A cidade deve ser preenchida.");
        }
    }
}
