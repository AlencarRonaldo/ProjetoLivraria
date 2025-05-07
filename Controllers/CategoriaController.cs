using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _repository.ListarTodosAsync();
            return Ok(categorias);
        }
        [HttpPost]
        
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);
            return Created();
        }
     }

}
