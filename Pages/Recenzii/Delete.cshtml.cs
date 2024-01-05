using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Recenzii
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DeleteModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Recenzie Recenzie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie = await _context.Recenzie.FirstOrDefaultAsync(m => m.Id == id);

            if (recenzie == null)
            {
                return NotFound();
            }
            else 
            {
                Recenzie = recenzie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }
            var recenzie = await _context.Recenzie.FindAsync(id);

            if (recenzie != null)
            {
                Recenzie = recenzie;
                _context.Recenzie.Remove(Recenzie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
