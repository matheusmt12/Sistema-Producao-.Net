using System;
using System.Collections.Generic;

namespace Core;

public partial class Mprima
{
    public int IdMprima { get; set; }

    public string NomeMateriaPrima { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int QntEstoque { get; set; }

    public virtual ICollection<Fornecedor> FornecedorIdFornecedors { get; set; } = new List<Fornecedor>();

    public virtual ICollection<Producao> ProducaoIdProducaos { get; set; } = new List<Producao>();
}
