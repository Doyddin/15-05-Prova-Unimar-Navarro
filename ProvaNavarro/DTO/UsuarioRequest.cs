using ProvaNavarro.Model;
using System.ComponentModel.DataAnnotations;

namespace ProvaNavarro.DTO
{
    public class UsuarioRequest
    {
        [MinLength(5)]
        public string Nome { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public Usuario toModel() 
            => new Usuario(Nome, Email);
    }
}
