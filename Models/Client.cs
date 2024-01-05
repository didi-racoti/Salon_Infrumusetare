using System.ComponentModel.DataAnnotations;

namespace Salon_Infrumusetare.Models
{
    public class Client
    {
        public int ID { get; set; }

        [StringLength(25, ErrorMessage = "Prenumele serviciului trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Prenumele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string? Prenume { get; set; }

        [StringLength(25, ErrorMessage = "Numele serviciului trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Numele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string? Nume { get; set; }

        [RegularExpression(@"^0\d{3}[-. ]?\d{3}[-. ]?\d{3}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu cifra 0 si sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }

        public string Email { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
    }
}
