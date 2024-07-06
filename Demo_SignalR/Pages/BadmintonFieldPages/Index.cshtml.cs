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
    public class IndexModel : PageModel
    {
        private readonly Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext _context;

        public IndexModel(Demo_SignalR.Entity.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IList<BadmintonField> BadmintonField { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BadmintonField = await _context.BadmintonFields.ToListAsync();
        }

        public async Task<IActionResult> OnGetFieldsAsync()
        {
            BadmintonField = await _context.BadmintonFields.ToListAsync();
            return new JsonResult(BadmintonField);
        }

    }
}
