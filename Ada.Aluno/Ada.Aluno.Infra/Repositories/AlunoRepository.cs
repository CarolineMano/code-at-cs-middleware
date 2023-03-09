using Ada.Aluno.Application.Interfaces.Repositories;

namespace Ada.Aluno.Infra.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly SqlServerConnection _connection;

        public AlunoRepository(SqlServerConnection connection)
        {
            _connection = connection;
        }

        public void Add(Core.Aluno aluno)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Alunos (Id, Nome, Cidade, NomeDaMae)" + 
                    $"VALUES ('{aluno.Id}', '{aluno.Nome}', '{aluno.Cidade}', '{aluno.NomeMae}')";
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Guid id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM Alunos WHERE Id='{id}'";

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Core.Aluno> GetAll()
        {
            var alunos = new List<Core.Aluno>();
            
            using var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Alunos";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                alunos.Add(new Core.Aluno(
                    (Guid)reader["Id"], 
                    (string)reader["Nome"], 
                    (string)reader["Cidade"], 
                    (string)reader["NomeDaMae"]
                    ));
            }

            return alunos;
        }

        public Core.Aluno GetById(Guid id)
        {
            using var command = _connection.CreateCommand();
            
            command.CommandText = $"SELECT * FROM Alunos WHERE Id='{id}'";

            using var reader = command.ExecuteReader();
            reader.Read();

            return new Core.Aluno(
                    (Guid)reader["Id"],
                    (string)reader["Nome"],
                    (string)reader["Cidade"],
                    (string)reader["NomeDaMae"]
                    );
        }

        public void Update(Core.Aluno aluno)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Alunos SET Nome = '{aluno.Nome}', Cidade = '{aluno.Cidade}', NomeDaMae = '{aluno.NomeMae}'" +
                    $"WHERE Id='{aluno.Id}'";

                command.ExecuteNonQuery();
            }
        }
    }
}
