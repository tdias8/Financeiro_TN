using Financeiro_TN.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Financeiro_TN.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NF> NotasFiscais { get; set; }
    }

}