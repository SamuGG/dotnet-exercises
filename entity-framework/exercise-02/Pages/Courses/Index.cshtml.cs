using EFDemo02.Data;
using EFDemo02.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFDemo02.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; } = default!;
        public string TitleSort { get; set; } = default!;
        public string CreditsSort { get; set; } = default!;
        public string CurrentSort { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CreditsSort = sortOrder == "Credits" ? "credits_desc" : "Credits";

            IQueryable<Course> coursesIQ = from s in _context.Courses
                                           select s;

            coursesIQ = sortOrder switch
            {
                "title_desc" => coursesIQ.OrderByDescending(c => c.Title),
                "Credits" => coursesIQ.OrderBy(s => s.Credits),
                "credits_desc" => coursesIQ.OrderByDescending(s => s.Credits),
                _ => coursesIQ.OrderBy(s => s.Title),
            };

            Courses = await coursesIQ.AsNoTracking().ToListAsync();
        }
    }
}
