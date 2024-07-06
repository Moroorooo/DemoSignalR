using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo_SignalR.Entity;
using Microsoft.AspNetCore.SignalR;

namespace Demo_SignalR.Pages.BadmintonFieldPages
{
    public class EditModel : PageModel
    {
        private readonly Net1702_PRN221_BadmintonRentingContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;

        public EditModel(Net1702_PRN221_BadmintonRentingContext context, IHubContext<SignalrServer> signalRHub)
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

            var badmintonfield =  await _context.BadmintonFields.FirstOrDefaultAsync(m => m.BadmintonFieldId == id);
            if (badmintonfield == null)
            {
                return NotFound();
            }
            BadmintonField = badmintonfield;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BadmintonField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("ReceiveUpdatedField", BadmintonField);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadmintonFieldExists(BadmintonField.BadmintonFieldId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BadmintonFieldExists(long id)
        {
          return (_context.BadmintonFields?.Any(e => e.BadmintonFieldId == id)).GetValueOrDefault();
        }
    }
}
