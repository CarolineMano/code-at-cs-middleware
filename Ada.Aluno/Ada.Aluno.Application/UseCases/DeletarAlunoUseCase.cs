using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.UseCases
{
    public class DeletarAlunoUseCase : IDeletarAlunoUseCase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public DeletarAlunoUseCase(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public ApiResponse Execute(Guid id)
        {
            try
            {
                _pessoaRepository.Delete(id);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Messages = new List<string> { ex.Message }
                };
            }
        }
    }
}
