using System.ComponentModel.DataAnnotations;

namespace Salon_Infrumusetare.Models
{
    public class Programare
    {
        public int Id { get; set; }
        public int ClientID {  get; set; }
        public Client? Client { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        public int SpecialistID { get; set; }
        public Specialist? Specialist { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data nu este valida.")]
        [Range(typeof(DateTime), "01/01/2024", "12/31/2100", ErrorMessage = "Ora trebuie să fie între 01/01/2024 și 12/31/2100.")]
        public DateTime Ora { get; set; }
    }
}
