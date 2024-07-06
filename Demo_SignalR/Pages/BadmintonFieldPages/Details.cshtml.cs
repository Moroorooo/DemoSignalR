using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Demo_SignalR.Entity;

namespace Demo_SignalR.Pages.BadmintonFieldPages
{
    public class DetailsModel : PageModel
    {
        private readonly Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext _context;

        public DetailsModel(Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

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
    }
}
