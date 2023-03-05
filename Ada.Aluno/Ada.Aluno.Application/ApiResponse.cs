using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Application
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Messages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
        public List<string> Messages { get; set; }
    }
}
