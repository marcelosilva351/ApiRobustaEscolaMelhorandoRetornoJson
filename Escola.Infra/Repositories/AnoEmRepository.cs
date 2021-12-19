using Escola.Domain.Entidades;
using Escola.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories
{
    public class AnoEmRepository : Repository<AnoEnsinoMedio>, IAnoEmRepository
    {
        public AnoEmRepository(ApiContext context) : base(context)
        {
        }
    }
}
