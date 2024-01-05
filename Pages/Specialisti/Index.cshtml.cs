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
    public class IndexModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public IndexModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        public IList<Specialist> Specialist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specialist != null)
            {
                Specialist = await _context.Specialist.ToListAsync();
            }
        }
    }
}
