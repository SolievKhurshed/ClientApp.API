using System;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.ClientApp.Data.Entities
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(1024)]
        public string OrganizationShortName { get; set; }

        [Required]
        [MaxLength(2048)]
        public string OrganizationFullName { get; set; }

        [Required]
        [MaxLength(12)]
        public string INN { get; set; }

        [MaxLength(9)]
        public string KPP { get; set; }

        [Required]
        public ClientType ClientType { get; set; }

        [Required]
        public ClientGroup ClientGroup { get; set; }

        [Required]
        [MaxLength(500)]
        public string PostalAddress { get; set; }

        [Required]
        [MaxLength(500)]
        public string FactAddress { get; set; }

        [Required]
        [MaxLength(500)]
        public string LegalAddress { get; set; }

        public ClientContact ClientContact { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Incorrect email.")]
        public string Email { get; set; }

        [MaxLength(30)]
        [RegularExpression(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Incorrect mobile phone number (allowed +7XXX-XXX-XX-XX, where X is a positive number).")]
        public string Phone { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime CreatedDt { get; set; }

        [Required]
        public DateTime ModifiedDt { get; set; }

        [Required]
        public DateTime LastViewedDt { get; set; }

        [Required]
        public Card Card { get; set; }
    }
}
