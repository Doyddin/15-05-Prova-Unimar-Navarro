using System.ComponentModel.DataAnnotations;

namespace ProvaNavarro.DTO
{
    public class PostUpdate
    {
        [MinLength(10)]
        public string Conteudo { get; set; }
    }
}
