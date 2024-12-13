using System;
using System.Collections.Generic;

namespace Core;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime DataPedido { get; set; }

    public DateTime DataEntregaPrevista { get; set; }

    public DateTime? DataEntregaEfetuada { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public int ClienteIdCliente { get; set; }

    public virtual Cliente ClienteIdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Produto> ProdutoIdProdutos { get; set; } = new List<Produto>();
}
