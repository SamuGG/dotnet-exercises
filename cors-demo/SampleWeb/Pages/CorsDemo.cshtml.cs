using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleWeb.Pages;

public class CorsDemoModel : PageModel
{
    private readonly ILogger<CorsDemoModel> _logger;

    public CorsDemoModel(ILogger<CorsDemoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
