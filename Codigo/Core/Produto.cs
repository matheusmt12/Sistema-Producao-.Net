using System;
using System.Collections.Generic;

namespace Core;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public decimal Valor { get; set; }

    public int Estoque { get; set; }

    public virtual ICollection<Producao> Producaos { get; set; } = new List<Producao>();

    public virtual ICollection<Pedido> PedidoIdPedidos { get; set; } = new List<Pedido>();
}
