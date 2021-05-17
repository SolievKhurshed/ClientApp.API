namespace ClientApp.API.Models
{
    public class ClientShortInfoModel
    {        
        public int Id { get; set; }      
        public string OrganizationShortName { get; set; }      
        public string INN { get; set; }       
        public string ClientType { get; set; }       
        public string ClientGroup { get; set; }     
        public string LegalAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
