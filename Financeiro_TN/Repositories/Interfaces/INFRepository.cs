using Financeiro_TN.Models;
using System.Collections.Generic;
using System.Numerics;

namespace Financeiro_TN.Repositories.Interfaces
{
    public interface INFRepository
    {
        IEnumerable<NF> NFs { get; }
    }
}
