using System;
using System.Collections.Generic;

namespace ApiContabilidade.Models
{
    public partial class TransacoesFinanceira
    {
        public int IdTransacao { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoTransacao { get; set; }
        public DateTime? DataTransacao { get; set; }
        public decimal? ValorTransacao { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
