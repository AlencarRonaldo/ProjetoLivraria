using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    public class LivrosContext : DbContext
    {
        // Cada Tabela -> DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // String de Conexão
            optionsBuilder.UseSqlServer("Data Source=NOTE32-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                // Representacao da Tabela
                entity =>
                {
                    // Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    entity.Property(u => u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    // Email é Unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    entity.Property(u => u.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(u => u.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                    entity.Property(u => u.DataCadastro)
                    .IsRequired();

                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();

                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                // Confiro primary key
                entity.HasKey(t => t.TipoUsuarioId);
                
                // VOu campo a campo configurando
                entity .Property(t => t.DescricaoTipo)
                .IsRequired()
                .HasMaxLength (100)
                .IsUnicode(false);

                //Descricao nao pode repetir
                // TODO campo INIQUE e um indice
                entity.HasIndex(t => t.DescricaoTipo)
                .IsUnique();

            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(l => l.LivroId);

                entity.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.Property(l => l.Descricao)
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(l => l.DataPublicacao)
               .IsRequired();

                //RELACIONAMENTO ENTRE TABELAS
                //LIVRO - CATEGORIA
                // 1 para N(muitos)
                entity.HasOne(l => l.Categoria)
                .WithMany(c => c.Livros)
                .HasForeignKey(l => l.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
            
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.CategoriaId);
                entity.Property(c => c.NomeCategoria)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Assinatura>(entity =>
            {
                entity.HasKey(a => a.AssinaturaId);

                entity.Property(a => a.DataInicio)
                .IsRequired();

                entity.Property(a => a.DataFim)
                .IsRequired();

                entity.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                //RELACIONAMENTO ENTRE TABELAS
                //usuario - assinatura
                // 1 para N(muitos)
                entity.HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            });



        }
    }
}
