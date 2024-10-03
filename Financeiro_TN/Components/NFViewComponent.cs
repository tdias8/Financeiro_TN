using Financeiro_TN.Data;
using Financeiro_TN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financeiro_TN.Components
{
    public class NFViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public NFViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string mesEmissao, string mesCobranca, string mesPagamento, int? status)
        {
            var notas = _context.NotasFiscais.AsQueryable();

            if (!string.IsNullOrEmpty(mesEmissao))
            {
                DateTime dataEmissaoInicio = DateTime.Parse(mesEmissao + "-01");
                DateTime dataEmissaoFim = dataEmissaoInicio.AddMonths(1).AddDays(-1);
                notas = notas.Where(n => n.DataEmissao >= dataEmissaoInicio && n.DataEmissao <= dataEmissaoFim);
            }

            if (!string.IsNullOrEmpty(mesCobranca))
            {
                DateTime dataCobrancaInicio = DateTime.Parse(mesCobranca + "-01");
                DateTime dataCobrancaFim = dataCobrancaInicio.AddMonths(1).AddDays(-1);
                notas = notas.Where(n => n.DataCobranca >= dataCobrancaInicio && n.DataCobranca <= dataCobrancaFim);
            }

            if (!string.IsNullOrEmpty(mesPagamento))
            {
                DateTime dataPagamentoInicio = DateTime.Parse(mesPagamento + "-01");
                DateTime dataPagamentoFim = dataPagamentoInicio.AddMonths(1).AddDays(-1);
                notas = notas.Where(n => n.DataPagamento >= dataPagamentoInicio && n.DataPagamento <= dataPagamentoFim);
            }

            if (status.HasValue)
            {
                notas = notas.Where(n => n.Status == (EnumStatusNota)status.Value);
            }

            return View(await notas.ToListAsync());
        }
    }
}
