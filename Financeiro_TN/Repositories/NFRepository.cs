using Financeiro_TN.Data;
using Financeiro_TN.Models;
using Financeiro_TN.Repositories.Interfaces;

namespace Financeiro_TN.Repositories
{
    public class NFRepository : INFRepository
    {
        private readonly AppDbContext _context;

        public NFRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<NF> NFs => _context.NotasFiscais;
    }
}
