using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private LivrosContext _context;
        public UsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public void Atualuzar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado == null)
            {
                throw new Exception();
            }
        }

        public Usuario BuscarPoremailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> BuscarUsuarioPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            var categoria = _context.Usuarios.Find(id);
            if (categoria == null) return null;
        }

        public List<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
