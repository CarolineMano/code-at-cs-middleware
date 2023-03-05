using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Requests;
using Ada.Aluno.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.UseCases
{
    public class EditarAlunoUseCase : IEditarAlunoUseCase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public EditarAlunoUseCase(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public ApiResponse Execute(Guid id, CriarAlunoRequest request)
        {
            try
            {
                var aluno = new Core.Aluno(
                    id,
                    request.Nome,
                    request.Cidade,
                    request.NomeMae);

                if (!aluno.IsValid)
                {
                    return new ApiResponse
                    {
                        StatusCode = System.Net.HttpStatusCode.Conflict,
                        Messages = aluno.Messages
                    };
                }

                _pessoaRepository.Update(aluno);

                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = aluno
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
