using System;
using System.Collections.Generic;

namespace Core;

public partial class Fornecedor
{
    public int IdFornecedor { get; set; }

    public string Rua { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string NumLocal { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? RazaoSocial { get; set; }

    public virtual ICollection<Mprima> MprimaIdMprimas { get; set; } = new List<Mprima>();
}
