using System.ComponentModel.DataAnnotations;

namespace Salon_Infrumusetare.Models
{
    public class Recenzie
    {
        public int Id { get; set; }

        [StringLength(25, ErrorMessage = "Numele trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Numele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Nume { get; set; }

        [StringLength(25, ErrorMessage = "Prenumele trebuie sa aiba cel putin 3 caractere", MinimumLength = 3)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-]*$", ErrorMessage = "Prenumele trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si liniute.")]
        public string Prenume { get; set; }

        [StringLength(25, ErrorMessage = "Comentariul trebuie sa aiba cel putin 2 caractere", MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s\-.,'!?]*$", ErrorMessage = "Comentariul trebuie să înceapă cu o literă mare și să conțină doar litere, spatii si semne de punctuatie.")]
        public string Comentariu { get; set; }

        [Range(1, 10, ErrorMessage = "Nota acordata trebuie să fie între 1 și 10.")]
        [Required]
        public int Nota { get; set; }
    }
}
