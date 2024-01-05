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
    public class DetailsModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DetailsModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

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
            else 
            {
                Specialist = specialist;
            }
            return Page();
        }
    }
}
