using System;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.Models
{
    public class ClientUpdateDto
    {
        [Required (ErrorMessage = "Необходимо указать краткое наименование организации")]
        [MaxLength(1024)]
        public string OrganizationShortName { get; set; }

        [Required(ErrorMessage = "Необходимо указать полное наименование организации")]
        [MaxLength(2048)]
        public string OrganizationFullName { get; set; }

        [Required(ErrorMessage = "Необходимо указать ИНН организации")]
        [MaxLength(12)]
        public string INN { get; set; }

        [MaxLength(9)]
        public string KPP { get; set; }

        [Required(ErrorMessage = "Необходимо указать почтовый адрес организации")]
        [MaxLength(500)]
        public string PostalAddress { get; set; }

        [Required(ErrorMessage = "Необходимо указать фактический адрес организации")]
        [MaxLength(500)]
        public string FactAddress { get; set; }

        [Required(ErrorMessage = "Необходимо указать юридический адрес организации")]
        [MaxLength(500)]
        public string LegalAddress { get; set; }

        [Required(ErrorMessage = "Необходимо указать электронный адрес организации")]
        [MaxLength(100)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Incorrect email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо указать телефон организации")]
        [MaxLength(30)]
        [RegularExpression(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Incorrect mobile phone number (allowed +7XXX-XXX-XX-XX, where X is a positive number).")]
        public string Phone { get; set; }

        public DateTime ModifiedDt { get; set; } = DateTime.Now;
    }
}
