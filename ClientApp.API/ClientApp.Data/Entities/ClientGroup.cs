using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class ClientGroup
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string GroupName { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
    }
}
