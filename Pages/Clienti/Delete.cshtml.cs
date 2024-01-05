using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Data;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Pages.Clienti
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public DeleteModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(c => c.Serviciu).FirstOrDefaultAsync(m => m.ID == id);

            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }

        bool Verificare(Client client)
        {
            return _context.Programare.Any(p => p.ClientID == client.ID);
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(c => c.Serviciu).FirstOrDefaultAsync(m => m.ID == id);

            if (client == null)
            {
                return NotFound();
            }

            bool clientFolosit = Verificare(client);

            if (!clientFolosit)
            {
                _context.Entry(client).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Nu puteți șterge clientul deoarece este deja utilizat în pagina de programări.");
                Client = client;
                return Page();
            }
        }
    }
}
