using ProvaNavarro.Model;

namespace ProvaNavarro.DTO
{
    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public UsuarioResponse(Usuario usuario)
        {
            Nome = usuario.Nome;
            Email = usuario.Email;
        }
    }
}
