using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo_SignalR.Entity;
using Microsoft.AspNetCore.SignalR;

namespace Demo_SignalR.Pages.BadmintonFieldPages
{
    public class CreateModel : PageModel
    {
        private readonly Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;
        public CreateModel(Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext context, IHubContext<SignalrServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BadmintonField BadmintonField { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BadmintonFields == null || BadmintonField == null)
            {
                return Page();
            }

            _context.BadmintonFields.Add(BadmintonField);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("ReceiveCreateField", BadmintonField);

            return RedirectToPage("./Index");
        }
    }
}
