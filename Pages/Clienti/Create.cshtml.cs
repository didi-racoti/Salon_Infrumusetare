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
    public class CreateModel : PageModel
    {
        private readonly Salon_Infrumusetare.Data.Salon_InfrumusetareContext _context;

        public CreateModel(Salon_Infrumusetare.Data.Salon_InfrumusetareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var serviciuList = _context.Serviciu.Select(x => new
            {
                x.ID,
                Text = x.Nume + " " + x.Minute + " minute" + " - " + x.Pret + " lei"
            });
            //ViewData["ServiciuID"] = new SelectList(_context.Set<Serviciu>(), "ID", "Text");
            ViewData["Serviciu"] = new SelectList(serviciuList, "ID", "Text");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Client == null || Client == null)
            {
                return Page();
            }

            if (Client.Serviciu == null)
            {
                Client.Serviciu = await _context.Serviciu.FindAsync(Client.ServiciuID);
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
