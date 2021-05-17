using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class ClientContact
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Post { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Incorrect email.")]
        public string Email { get; set; }

        [MaxLength(30)]
        [RegularExpression(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Incorrect mobile phone number (allowed +7XXX-XXX-XX-XX, where X is a positive number).")]
        public string MobilePhone { get; set; }
    }
}
