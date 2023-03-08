using Ada.Aluno.Application.Interfaces.Repositories;

namespace Ada.Aluno.Infra
{
    public class PessoaRepository : IAlunoRepository
    {
        private static List<Core.Aluno> _alunos;

        static PessoaRepository()
        {
            _alunos = new List<Core.Aluno>();
        }

        public void Add(Core.Aluno aluno)
        {
            _alunos.Add(aluno);
        }

        public void Delete(Guid id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);

            if(aluno is default(Core.Aluno))
                throw new Exception("Id informado não existe");

            _alunos.Remove(aluno);
        }

        public void Update(Core.Aluno aluno)
        {
            var alunoBd = _alunos.FirstOrDefault(a => a.Id == aluno.Id);

            if (alunoBd is default(Core.Aluno))
                throw new Exception("Id informado não existe");

            _alunos.Remove(alunoBd);
            _alunos.Add(aluno);
        }

        public Core.Aluno GetById(Guid id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);

            if (aluno is default(Core.Aluno))
                throw new Exception("Id informado não existe");

            return aluno;
        }

        public IEnumerable<Core.Aluno> GetAll()
        {
            return _alunos;
        }
    }
}
