using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class NotificationSubscriber
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
