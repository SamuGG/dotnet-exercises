using EFDemo02.Data;
using EFDemo02.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFDemo02.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = default!;
        public string CurrentFilter { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s =>
                    s.LastName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                    || s.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
            }

            if (_context.Students != null)
            {
                Students = await studentsIQ.AsNoTracking().ToListAsync();
            }
        }
    }
}
