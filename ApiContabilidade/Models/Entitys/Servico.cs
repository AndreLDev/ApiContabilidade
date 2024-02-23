using System;
using System.Collections.Generic;

namespace ApiContabilidade.Models.Entitys
{
    public partial class Servico
    {
        public int IdServico { get; set; }
        public string? DescricaoServico { get; set; }
        public decimal? TaxaServico { get; set; }
    }
}
