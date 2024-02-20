using System;
using System.Collections.Generic;
using ApiContabilidade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiContabilidade.Context
{
    public partial class ContabilidadeDBContext : DbContext
    {
        public ContabilidadeDBContext()
        {
        }

        public ContabilidadeDBContext(DbContextOptions<ContabilidadeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DeclaracoesFinanceira> DeclaracoesFinanceiras { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Servico> Servicos { get; set; } = null!;
        public virtual DbSet<TransacoesFinanceira> TransacoesFinanceiras { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=PC03LAB2538\\SENAI; Database=ContabilidadeDB; User Id=sa; Password=senai.123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F55B7E0813");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.EnderecoCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("endereco_cliente");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_cliente");

                entity.Property(e => e.TelefoneCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefone_cliente");

                entity.Property(e => e.TipoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_cliente");
            });

            modelBuilder.Entity<DeclaracoesFinanceira>(entity =>
            {
                entity.HasKey(e => e.IdDeclaracao)
                    .HasName("PK__Declarac__1132B261778DC845");

                entity.Property(e => e.IdDeclaracao).HasColumnName("id_declaracao");

                entity.Property(e => e.ConteudoDeclaracao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("conteudo_declaracao");

                entity.Property(e => e.DataDeclaracao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_declaracao");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.TipoDeclaracao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_declaracao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DeclaracoesFinanceiras)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Declaraco__id_cl__3D5E1FD2");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PK__Funciona__6FBD69C4B2D22A24");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.CargoFuncionario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cargo_funcionario");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.NomeFuncionario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome_funcionario");

                entity.Property(e => e.TelefoneFuncionario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefone_funcionario");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.IdServico)
                    .HasName("PK__Servicos__D06FB5A29C3B848C");

                entity.Property(e => e.IdServico).HasColumnName("id_servico");

                entity.Property(e => e.DescricaoServico)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao_servico");

                entity.Property(e => e.TaxaServico)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("taxa_servico");
            });

            modelBuilder.Entity<TransacoesFinanceira>(entity =>
            {
                entity.HasKey(e => e.IdTransacao)
                    .HasName("PK__Transaco__0FBBF7731E967A0E");

                entity.Property(e => e.IdTransacao).HasColumnName("id_transacao");

                entity.Property(e => e.DataTransacao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_transacao");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.TipoTransacao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_transacao");

                entity.Property(e => e.ValorTransacao)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valor_transacao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TransacoesFinanceiras)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Transacoe__id_cl__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
