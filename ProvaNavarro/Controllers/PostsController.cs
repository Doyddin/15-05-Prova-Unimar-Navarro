using Microsoft.AspNetCore.Mvc;
using ProvaNavarro.Context;
using ProvaNavarro.DTO;
using ProvaNavarro.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaNavarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly DataContext _dataContext;
        public PostsController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<PostsController>
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return _dataContext.Post.ToList();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var post = _dataContext.Post.FirstOrDefault(x => x.PostId == id);
            post.Usuario = _dataContext.Usuario.FirstOrDefault(y => y.UsuarioId == post.UsuarioId);

            if (post == null)
            {
                return BadRequest("Id não Existente");
            }

            return post;
        }

        // POST api/<PostsController>
        [HttpPost]
        public ActionResult<Post> Post([FromBody] PostRequest postRequest)
        {
            if (ModelState.IsValid)
            {
                var post = postRequest.toModel();

                var usuario = _dataContext.Usuario.FirstOrDefault(x => x.UsuarioId == post.UsuarioId);
                
                if (usuario == null)
                {
                    return BadRequest("Id de Usuário não existente");
                }

                _dataContext.Post.Add(post);
                _dataContext.SaveChanges();
                return post;
            }

            return BadRequest(ModelState);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public ActionResult<Post> Put(int id, [FromBody] PostUpdate postUpdate)
        {
            var post = _dataContext.Post.FirstOrDefault(x => x.PostId == id);

            if (post == null)
            {
                return BadRequest("Id de usuário não existente");
            }

            post.Conteudo = postUpdate.Conteudo;

            _dataContext.SaveChanges();

            return post;

        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _dataContext.Post.FirstOrDefault(x => x.PostId == id);

            if (post != null)
            {
                _dataContext.Post.Remove(post);
                _dataContext.SaveChanges();
                return Ok("Post excluido.");
            }

            return BadRequest("Id não existente");
        }
    }
}
