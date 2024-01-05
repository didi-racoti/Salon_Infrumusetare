using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Programari
{
    public class EditModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public EditModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare =  await _context.Programare.FirstOrDefaultAsync(m => m.Id == id);
            if (programare == null)
            {
                return NotFound();
            }
            Programare = programare;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgramareExists(int id)
        {
          return (_context.Programare?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
