using System;
using System.Collections.Generic;

namespace ApiContabilidade.Models.Entitys
{
    public partial class DeclaracoesFinanceira
    {
        public int IdDeclaracao { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoDeclaracao { get; set; }
        public DateTime? DataDeclaracao { get; set; }
        public string? ConteudoDeclaracao { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
