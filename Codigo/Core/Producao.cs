using System;
using System.Collections.Generic;

namespace Core;

public partial class Producao
{
    public int IdProducao { get; set; }

    public int QntProduzida { get; set; }

    public decimal CustoLote { get; set; }

    public DateTime DataEntrega { get; set; }

    public int ProdutoIdProduto { get; set; }

    public virtual Produto ProdutoIdProdutoNavigation { get; set; } = null!;

    public virtual ICollection<Mprima> MprimaIdMprimas { get; set; } = new List<Mprima>();
}
