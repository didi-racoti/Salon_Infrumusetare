using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Specialisti
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DeleteModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Specialist Specialist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specialist == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist.FirstOrDefaultAsync(m => m.ID == id);

            if (specialist == null)
            {
                return NotFound();
            }
            
            Specialist = specialist;
            return Page();
        }

        bool Verificare(Specialist specialist)
        {
           return _context.Programare.Any(p => p.SpecialistID == specialist.ID);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist.FindAsync(id);

            if (specialist == null)
            {
                return NotFound();
            }

            bool specialistFolosit = Verificare(specialist);

            if (!specialistFolosit)
            {
                _context.Entry(specialist).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Nu puteți șterge specialistul deoarece este deja utilizat în pagina de programări.");
                Specialist = specialist;
                return Page();
            }
        }
    }
}
