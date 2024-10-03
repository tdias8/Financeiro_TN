using Financeiro_TN.Data;
using Financeiro_TN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financeiro_TN.Components
{
    public class DashboardViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DashboardViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string mes, string trimestre, string ano)
        {
            var notas = _context.NotasFiscais.AsQueryable();

            if (!string.IsNullOrEmpty(mes))
            {
                var mesInt = int.Parse(mes);
                notas = notas.Where(n => n.DataEmissao.Month == mesInt);
            }

            if (!string.IsNullOrEmpty(trimestre))
            {
                var trimestreInt = int.Parse(trimestre);
                notas = notas.Where(n => (n.DataEmissao.Month - 1) / 3 + 1 == trimestreInt);
            }

            if (!string.IsNullOrEmpty(ano))
            {
                var anoInt = int.Parse(ano);
                notas = notas.Where(n => n.DataEmissao.Year == anoInt);
            }

            var resultados = await notas.ToListAsync();

            var dashboard = new Dashboard
            {
                TotalNotasEmitidas = resultados.Sum(n => n.Valor), 
                TotalSemCobranca = resultados.Where(n => string.IsNullOrEmpty(n.DocBoleto)).Sum(n => n.Valor),
                TotalVencidas = resultados.Where(n => n.DataCobranca < DateTime.Now).Sum(n => n.Valor), 
                TotalAVencer = resultados.Where(n => n.DataCobranca >= DateTime.Now).Sum(n => n.Valor), 
                TotalPagas = resultados.Where(n => n.DataPagamento != null).Sum(n => n.Valor) 
            };

            return View(dashboard);
        }
    }
}
