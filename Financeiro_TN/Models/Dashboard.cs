namespace Financeiro_TN.Models
{
    public class Dashboard
    {

        public decimal TotalNotasEmitidas { get; set; }
        public decimal TotalSemCobranca { get; set; }
        public decimal TotalVencidas { get; set; }
        public decimal TotalAVencer { get; set; }
        public decimal TotalPagas { get; set; }
        public List<decimal> InadimplenciaMensal { get; set; }
        public List<decimal> ReceitaMensal { get; set; }
    }
}
