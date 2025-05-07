using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ICategoriaRepository
    {
        // Assicrono - todos os metodos restornan task(tarefa)
        Task<List<Categoria>> ListarTodosAsync();

       void Cadastrar (Categoria categoria);
       Categoria? Atualizar (int id, Categoria categoria);
       Categoria? Deletar (int id);
       

    }
}
