using System;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.API.Services.ReportEvent
{
    public class ReportEventModel
    {
        public DateTime CreatedDT { get; set; }        
        public string UserFullName { get; set; }
        public ReportEventType ReportEventType { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public string OrganizationShortName { get; set; }
    }

    public enum ReportEventType
    {
        [Display(Name = "Запрос подробной информации")]
        RequestFullInformation = 0,

        [Display(Name = "Изменение реквизитов клиента")]
        UpdateClient = 1
    }
}
