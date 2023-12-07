using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class MarcasAutosController : Controller
{
    private readonly DataContext _context;
    private readonly ILogger<MarcasAutosController> _logger;

    public MarcasAutosController(
        DataContext context,
        ILogger<MarcasAutosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetMarcasAutos")]
    public IEnumerable<MarcasAutos> Index()
    {
        return _context.MarcasAutos.ToArray();
    }
}
