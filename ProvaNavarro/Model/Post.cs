using System.ComponentModel.DataAnnotations;

namespace ProvaNavarro.Model
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string Conteudo { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public Post(string conteudo, int usuarioId)
        {
            Conteudo = conteudo;
            UsuarioId = usuarioId;
        }
    }
}
