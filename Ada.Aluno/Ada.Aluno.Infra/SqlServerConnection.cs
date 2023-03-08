using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Infra
{
    public class SqlServerConnection : IDisposable
    {
        private readonly SqlConnection _connection;
        public SqlServerConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
