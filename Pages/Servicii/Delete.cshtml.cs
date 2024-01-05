using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Servicii
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DeleteModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);

            if (serviciu == null)
            {
                return NotFound();
            }
            //else 
            //{
                Serviciu = serviciu;
            //}
            return Page();
        }

        bool Verificare(Serviciu serviciu)
        {
            return _context.Client.Any(c => c.ServiciuID == serviciu.ID) || _context.Programare.Any(p => p.ServiciuID == serviciu.ID);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FindAsync(id);

            if (serviciu == null)
            {
                return NotFound();
            }

            bool serviciuFolosit = Verificare(serviciu);

            if (!serviciuFolosit)
            {
                _context.Entry(serviciu).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Nu puteti sterge serviciul deoarece este deja utilizat in paginile de clieti sau programari.");
                Serviciu = serviciu;
                return Page();
            }
        }
    }
}
