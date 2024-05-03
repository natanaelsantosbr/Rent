using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Services.Accounts
{
    public class UserResult
    {
        public UserResult()
        {
            this.Erros = new List<string>();
        }

        public UserResult(Guid? id) : this()
        {
            Id = id;
        }

        public UserResult(IEnumerable<string> erros) : this()
        {
            Erros = erros;
        }

        public Guid? Id { get; set; }

        public IEnumerable<string> Erros { get; set; }
    }
}
