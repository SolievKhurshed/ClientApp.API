using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class ClientType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string TypeName { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
    }
}
