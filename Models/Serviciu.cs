using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon_Infrumusetare.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [StringLength(25, ErrorMessage = "Numele serviciului trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Numele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Nume { get; set; }
        public int? SpecialistID { get; set; }
        public Specialist? Specialist { get; set; }

        [Range(1, 240, ErrorMessage = "Valoarea trebuie să fie între 1 și 240.")]
        [Required]
        public int Minute { get; set; }
        public TimeSpan OraProgramare => TimeSpan.FromMinutes(Minute);

        [Range(1, 50000, ErrorMessage = "Valoarea trebuie să fie între 0 și 50000.")]
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Pret {  get; set; }
        public ICollection<Client>? Clienti { get; set; }//navigation property
    }
}
