using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Mapper;
using Ada.Aluno.Application.Output;
using Ada.Aluno.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application.UseCases
{
    public class ListarAlunosUseCase : IListarAlunosUseCase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public ListarAlunosUseCase(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public ApiResponse Execute()
        {
            try
            {
                var alunos = _pessoaRepository.GetAll();
                var alunosDto = alunos.Select(p => ListaOutputMap.Mapear(p)).ToList();


                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = alunosDto
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Messages = new List<string> { ex.Message }
                };
            }
        }
    }
}
