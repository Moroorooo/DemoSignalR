using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Demo_SignalR.Entity;
using Microsoft.AspNetCore.SignalR;

namespace Demo_SignalR.Pages.BadmintonFieldPages
{
    public class DeleteModel : PageModel
    {
        private readonly Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;
        public DeleteModel(Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext context, IHubContext<SignalrServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        [BindProperty]
      public BadmintonField BadmintonField { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.BadmintonFields == null)
            {
                return NotFound();
            }

            var badmintonfield = await _context.BadmintonFields.FirstOrDefaultAsync(m => m.BadmintonFieldId == id);

            if (badmintonfield == null)
            {
                return NotFound();
            }
            else 
            {
                BadmintonField = badmintonfield;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.BadmintonFields == null)
            {
                return NotFound();
            }
            var badmintonfield = await _context.BadmintonFields.FindAsync(id);

            if (badmintonfield != null)
            {
                BadmintonField = badmintonfield;
                _context.BadmintonFields.Remove(BadmintonField);
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("ReceiveDeletedField", id);
            }

            return RedirectToPage("./Index");
        }
    }
}
