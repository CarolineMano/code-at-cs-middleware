using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.Aluno.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public bool IsValid => Messages.Count == 0; 
    }
}
