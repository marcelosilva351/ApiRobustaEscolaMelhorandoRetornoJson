using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entidades
{
    public abstract class EntidadeUserBase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        internal List<string> _erros { get; set; } = new List<string>();

        public IReadOnlyCollection<string> GetErros { get { return _erros; } }

        public abstract bool Validar();
    }
}
