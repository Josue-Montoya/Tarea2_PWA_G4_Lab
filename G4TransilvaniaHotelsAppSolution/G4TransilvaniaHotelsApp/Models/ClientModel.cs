using System.ComponentModel;

namespace G4TransilvaniaHotelsApp.Models
{
    public class ClientModel
    {
        public int clientId { get; set; }

        [DisplayName("Nombre")]
        public string clientName { get; set; }

        [DisplayName("Email")]
        public string clientEmail { get; set; }

        [DisplayName("Teléfono")]
        public string clientPhone { get; set; }
    }
}
