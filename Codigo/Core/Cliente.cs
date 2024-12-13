using System;
using System.Collections.Generic;

namespace Core;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Rua { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string NomeResponsavel { get; set; } = null!;

    public string RamaAtivo { get; set; } = null!;

    public string RazaoSocial { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string NomeFantasia { get; set; } = null!;

    public int NumLocal { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
