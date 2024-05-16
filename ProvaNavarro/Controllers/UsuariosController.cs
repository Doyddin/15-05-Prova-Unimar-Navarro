using Microsoft.AspNetCore.Mvc;
using ProvaNavarro.Context;
using ProvaNavarro.DTO;
using ProvaNavarro.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaNavarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsuariosController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return _dataContext.Usuario.ToList();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _dataContext.Usuario.FirstOrDefault(x => x.UsuarioId == id);

            if (usuario == null)
            {
                return BadRequest("ID não Existente");
            }

            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] UsuarioRequest usuarioRequest)
        {
            if (ModelState.IsValid)
            {
                var usuario = usuarioRequest.toModel();
                _dataContext.Usuario.Add(usuario);
                _dataContext.SaveChanges();

                return usuario;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(int id, [FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = _dataContext.Usuario.FirstOrDefault(x => x.UsuarioId == id);

            if (usuario == null)
            {
                return BadRequest("Id de usuário não existente");
            }

            usuario.Nome = usuarioRequest.Nome;
            usuario.Email = usuarioRequest.Email;

            _dataContext.SaveChanges();

            return usuario;

        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _dataContext.Usuario.FirstOrDefault(x => x.UsuarioId == id);

            if (usuario != null)
            {
                _dataContext.Usuario.Remove(usuario);
                _dataContext.SaveChanges();
                return Ok("Usuário excluido.");
            }

            return BadRequest("Id não existente");
        }
    }
}
