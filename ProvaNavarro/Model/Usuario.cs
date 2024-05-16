using System.ComponentModel.DataAnnotations;

namespace ProvaNavarro.Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

    }
}
