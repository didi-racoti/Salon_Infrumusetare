using System.ComponentModel.DataAnnotations;

namespace Salon_Infrumusetare.Models
{
    public class Specialist
    {
        public int ID { get; set; }

        [StringLength (25, ErrorMessage = "Prenumele trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Prenumele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Prenume { get; set; }

        [StringLength(25, ErrorMessage = "Numele trebuie sa aiba cel putin 3 caractere", MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Numele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Nume { get; set; }

        [StringLength(25, ErrorMessage = "Specialitatea trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Specialitatea trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Specialitate { get; set; }

        [Range(1990, 2024, ErrorMessage = "Vechimea trebuie să fie între 1990 și 2024.")]
        [Required]
        public int AnVechime { get; set; }

        [RegularExpression(@"^0\d{3}[-. ]?\d{3}[-. ]?\d{3}$", ErrorMessage = "Numarul de telefon trebuie sa inceapa cu cifra 0 si sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }

        public string Instagram { get; set; }

    }
}
