using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class SistemaProducaoContext : DbContext
{
    public SistemaProducaoContext()
    {
    }

    public SistemaProducaoContext(DbContextOptions<SistemaProducaoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Mprima> Mprimas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producao> Producaos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=sistemaP");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.NomeFantasia)
                .HasMaxLength(45)
                .HasColumnName("nomeFantasia");
            entity.Property(e => e.NomeResponsavel)
                .HasMaxLength(45)
                .HasColumnName("nomeResponsavel");
            entity.Property(e => e.NumLocal).HasColumnName("numLocal");
            entity.Property(e => e.RamaAtivo)
                .HasMaxLength(45)
                .HasColumnName("ramaAtivo");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(45)
                .HasColumnName("razaoSocial");
            entity.Property(e => e.Rua)
                .HasMaxLength(45)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("PRIMARY");

            entity.ToTable("fornecedor");

            entity.HasIndex(e => e.Cnpj, "cnpj_UNIQUE").IsUnique();

            entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");
            entity.Property(e => e.Cidade)
                .HasMaxLength(45)
                .HasColumnName("cidade");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.NumLocal)
                .HasMaxLength(45)
                .HasColumnName("numLocal");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(45)
                .HasColumnName("razaoSocial");
            entity.Property(e => e.Rua)
                .HasMaxLength(45)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(45)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Mprima>(entity =>
        {
            entity.HasKey(e => e.IdMprima).HasName("PRIMARY");

            entity.ToTable("mprima");

            entity.Property(e => e.IdMprima).HasColumnName("idMPrima");
            entity.Property(e => e.Descricao)
                .HasMaxLength(70)
                .HasColumnName("descricao");
            entity.Property(e => e.NomeMateriaPrima)
                .HasMaxLength(45)
                .HasColumnName("nomeMateriaPrima");
            entity.Property(e => e.QntEstoque).HasColumnName("qntEstoque");

            entity.HasMany(d => d.FornecedorIdFornecedors).WithMany(p => p.MprimaIdMprimas)
                .UsingEntity<Dictionary<string, object>>(
                    "Mprimafornecedor",
                    r => r.HasOne<Fornecedor>().WithMany()
                        .HasForeignKey("FornecedorIdFornecedor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MPrima_has_Fornecedor_Fornecedor1"),
                    l => l.HasOne<Mprima>().WithMany()
                        .HasForeignKey("MprimaIdMprima")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MPrima_has_Fornecedor_MPrima1"),
                    j =>
                    {
                        j.HasKey("MprimaIdMprima", "FornecedorIdFornecedor").HasName("PRIMARY");
                        j.ToTable("mprimafornecedor");
                        j.HasIndex(new[] { "FornecedorIdFornecedor" }, "fk_MPrima_has_Fornecedor_Fornecedor1_idx");
                        j.HasIndex(new[] { "MprimaIdMprima" }, "fk_MPrima_has_Fornecedor_MPrima1_idx");
                        j.IndexerProperty<int>("MprimaIdMprima").HasColumnName("MPrima_idMPrima");
                        j.IndexerProperty<int>("FornecedorIdFornecedor").HasColumnName("Fornecedor_idFornecedor");
                    });

            entity.HasMany(d => d.ProducaoIdProducaos).WithMany(p => p.MprimaIdMprimas)
                .UsingEntity<Dictionary<string, object>>(
                    "Mprimaproducao",
                    r => r.HasOne<Producao>().WithMany()
                        .HasForeignKey("ProducaoIdProducao")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MPrima_has_Producao_Producao1"),
                    l => l.HasOne<Mprima>().WithMany()
                        .HasForeignKey("MprimaIdMprima")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MPrima_has_Producao_MPrima1"),
                    j =>
                    {
                        j.HasKey("MprimaIdMprima", "ProducaoIdProducao").HasName("PRIMARY");
                        j.ToTable("mprimaproducao");
                        j.HasIndex(new[] { "MprimaIdMprima" }, "fk_MPrima_has_Producao_MPrima1_idx");
                        j.HasIndex(new[] { "ProducaoIdProducao" }, "fk_MPrima_has_Producao_Producao1_idx");
                        j.IndexerProperty<int>("MprimaIdMprima").HasColumnName("MPrima_idMPrima");
                        j.IndexerProperty<int>("ProducaoIdProducao").HasColumnName("Producao_idProducao");
                    });
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.ClienteIdCliente, "fk_Pedido_Cliente_idx");

            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.ClienteIdCliente).HasColumnName("Cliente_idCliente");
            entity.Property(e => e.DataEntregaEfetuada)
                .HasColumnType("datetime")
                .HasColumnName("dataEntregaEfetuada");
            entity.Property(e => e.DataEntregaPrevista)
                .HasColumnType("datetime")
                .HasColumnName("dataEntregaPrevista");
            entity.Property(e => e.DataPedido)
                .HasColumnType("datetime")
                .HasColumnName("dataPedido");
            entity.Property(e => e.FormaPagamento)
                .HasColumnType("enum('PIX','DEBITO','CREDITO')")
                .HasColumnName("formaPagamento");

            entity.HasOne(d => d.ClienteIdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pedido_Cliente");
        });

        modelBuilder.Entity<Producao>(entity =>
        {
            entity.HasKey(e => e.IdProducao).HasName("PRIMARY");

            entity.ToTable("producao");

            entity.HasIndex(e => e.ProdutoIdProduto, "fk_Producao_Produto1_idx");

            entity.Property(e => e.IdProducao).HasColumnName("idProducao");
            entity.Property(e => e.CustoLote)
                .HasPrecision(10)
                .HasColumnName("custoLote");
            entity.Property(e => e.DataEntrega)
                .HasColumnType("datetime")
                .HasColumnName("dataEntrega");
            entity.Property(e => e.ProdutoIdProduto).HasColumnName("Produto_idProduto");
            entity.Property(e => e.QntProduzida).HasColumnName("qntProduzida");

            entity.HasOne(d => d.ProdutoIdProdutoNavigation).WithMany(p => p.Producaos)
                .HasForeignKey(d => d.ProdutoIdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Producao_Produto1");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PRIMARY");

            entity.ToTable("produto");

            entity.Property(e => e.IdProduto).HasColumnName("idProduto");
            entity.Property(e => e.Estoque).HasColumnName("estoque");
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(45)
                .HasColumnName("nomeProduto");
            entity.Property(e => e.Valor)
                .HasPrecision(10)
                .HasColumnName("valor");

            entity.HasMany(d => d.PedidoIdPedidos).WithMany(p => p.ProdutoIdProdutos)
                .UsingEntity<Dictionary<string, object>>(
                    "Produtopedido",
                    r => r.HasOne<Pedido>().WithMany()
                        .HasForeignKey("PedidoIdPedido")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Produto_has_Pedido_Pedido1"),
                    l => l.HasOne<Produto>().WithMany()
                        .HasForeignKey("ProdutoIdProduto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Produto_has_Pedido_Produto1"),
                    j =>
                    {
                        j.HasKey("ProdutoIdProduto", "PedidoIdPedido").HasName("PRIMARY");
                        j.ToTable("produtopedido");
                        j.HasIndex(new[] { "PedidoIdPedido" }, "fk_Produto_has_Pedido_Pedido1_idx");
                        j.HasIndex(new[] { "ProdutoIdProduto" }, "fk_Produto_has_Pedido_Produto1_idx");
                        j.IndexerProperty<int>("ProdutoIdProduto").HasColumnName("Produto_idProduto");
                        j.IndexerProperty<int>("PedidoIdPedido").HasColumnName("Pedido_idPedido");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
