using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public CreateModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            var clientNume = _context.Client.Select(x => new
            {
                x.ID,
                Text = x.Nume + " " + x.Prenume
            });
            ViewData["Nume"] = new SelectList(clientNume, "ID", "Text");

            var specialistNume = _context.Specialist.Select(x => new
            {
                x.ID,
                Text = x.Nume + " " + x.Prenume
            });
            ViewData["SpecialistNume"] = new SelectList(specialistNume, "ID", "Text");

            var serviciu = _context.Serviciu.Select(x => new
            {
                x.ID,
                Text = x.Nume
            });
            ViewData["Serviciu"] = new SelectList(serviciu, "ID", "Text");

            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Programare == null || Programare == null)
            {
                return Page();
            }
            if (Programare.Client == null)
            {
                Programare.Client = await _context.Client.FindAsync(Programare.ClientID);
            }
            if (Programare.Specialist == null)
            {
                Programare.Specialist = await _context.Specialist.FindAsync(Programare.SpecialistID);
            }
            if (Programare.Serviciu == null)
            {
                Programare.Serviciu = await _context.Serviciu.FindAsync(Programare.ServiciuID);
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
