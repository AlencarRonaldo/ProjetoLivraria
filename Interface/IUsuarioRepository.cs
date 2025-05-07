using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface IUsuarioRepository
    {
        //R - Read (Leitura)
        List<Usuario> ListarTodos();


        // Recebe um identificador, e 
        // retorna o prduto correspondente
       Usuario BuscarPorId(int id);
       Usuario BuscarPoremailSenha(string email, string senha);

        // C - Create (Cadastro    

        void Cadastrar(Usuario usuario);


        // U -UDADTE (atualixacao)
        //Recebe o identificador para encontrar o Produto e recebe o produto
        void Atualuzar(int id, Usuario usuario);

        // D  - Delete (Delete)
        // recebe o identificador de quem quer excluir

        void Deletar(int id);
        List<Usuario> BuscarUsuarioPorNome(string nome);
    }

    
}
