using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class CardMetadata
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Metadata { get; set; }
    }
}
