using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dwc.Data;
using dwc.Models;
using System.Threading.Tasks;

namespace dwc.Controllers
{
    public class RegistosMaoObraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistosMaoObraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistoMaoObra
        public async Task<IActionResult> Index()
        {
            var registos = await _context.RegistosMaoObra
                .Include(r => r.Obra)
                .ToListAsync();
            return View(registos);
        }

        // GET: RegistoMaoObra/Create
        public IActionResult Create()
        {
            ViewData["Obras"] = _context.Obras.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraId,NomePessoa,HorasTrabalhadas")] RegistoMaoObra registo)
        {
            if (ModelState.IsValid)
            {
                // DataHora já definido por default se tiveres no model
                _context.Add(registo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Obras"] = _context.Obras.ToList();
            return View(registo);
        }
    }
}
