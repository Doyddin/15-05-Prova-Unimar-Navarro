using ProvaNavarro.Model;
using System.ComponentModel.DataAnnotations;

namespace ProvaNavarro.DTO
{
    public class PostRequest
    {
        [MinLength(10)]
        public string Conteudo { get; set; }

        public int UsuarioId { get; set; }

        public Post toModel()
            => new Post(Conteudo, UsuarioId);
    }
}
