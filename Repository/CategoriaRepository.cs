using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    //1 Herdar e implementar
    //2 injetar o contexto

    public class CategoriaRepository : ICategoriaRepository
    {
        private LivrosContext _context;
        public CategoriaRepository(LivrosContext context)
        {
             _context = context;
        }

        public Categoria? Atualizar(int id, Categoria categoria)
        {
            var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => 
            c.CategoriaId == id);

            if (categoriaEncontrada == null) return null;

            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;

            _context.SaveChanges(); 
            return categoriaEncontrada;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null) return null;

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public List<Categoria> Listartodos()
        {
            return _context.Categorias.ToList();
        }  
        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
