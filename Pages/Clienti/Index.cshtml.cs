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

namespace Salon_Infrumusetare.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public IndexModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                //Client = await _context.Client.ToListAsync();
                Client = await _context.Client.Include(c => c.Serviciu).ToListAsync();
                //Client = await _context.Client.Include(c => c.Nume).Include(c => c.Prenume).Include(c => c.Serviciu).ToListAsync();


            }
        }
    }
}
