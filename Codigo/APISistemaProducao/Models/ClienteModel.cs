namespace APISistemaProducao.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Rua { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string NomeResponsavel { get; set; } = null!;

        public string RamaAtivo { get; set; } = null!;

        public string RazaoSocial { get; set; } = null!;

        public string Cnpj { get; set; } = null!;

        public string NomeFantasia { get; set; } = null!;

        public int NumLocal { get; set; }
    }
}
