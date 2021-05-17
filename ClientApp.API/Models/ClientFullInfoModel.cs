using ClientApp.API.ClientApp.Data.Entities;
using System;

namespace ClientApp.API.Models
{
    public class ClientFullInfoModel
    {
        public int Id { get; set; }
        public string OrganizationShortName { get; set; }
        public string OrganizationFullName { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime ModifiedDt { get; set; }
        public DateTime LastViewedDt { get; set; }
        public string ClientType { get; set; }
        public string ClientGroup { get; set; }
        public string LegalAddress { get; set; }
        public string FactAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserFullName { get; set; }
        public ClientContact ClientContact { get; set; }
        public string MetaData { get; set; }
    }
}
