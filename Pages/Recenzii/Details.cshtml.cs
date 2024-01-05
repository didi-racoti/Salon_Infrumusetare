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
    public class DetailsModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DetailsModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

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
    }
}
