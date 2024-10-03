using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro_TN.Models
{
    [Table("NotasFiscais")]
    public class NF
    {
        public int Id { get; set; }

        [Display(Name = "Nome Pagador")]
        [MaxLength(50)]
        public string NomePagador { get; set; }

        [Display(Name = "Número Nota Fiscal")]
        [MaxLength(50)]
        public string NumeroNF { get; set; }

        [Display(Name = "Data de Emissão")]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Data de Cobrança")]
        public DateTime DataCobranca { get; set; }

        [Display(Name = "Data de Pagamento")]
        public DateTime? DataPagamento { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        public decimal Valor { get; set; }

        [Display(Name = "Documento Nota Fiscal")]
        [MaxLength(50)]
        public string DocNF { get; set; }

        [Display(Name ="Documento Boleto")]
        [MaxLength(50)]
        public string DocBoleto { get; set; }
        public EnumStatusNota Status { get; set; }
    }
}
