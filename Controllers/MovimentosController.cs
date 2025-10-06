using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dwc.Data;
using dwc.Models;
using System.Threading.Tasks;

namespace dwc.Controllers
{
    public class MovimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimentos
        public async Task<IActionResult> Index()
        {
            var movimentos = await _context.Movimentos
                .Include(m => m.Obra)
                .Include(m => m.Material)
                .ToListAsync();
            return View(movimentos);
        }

        // GET: Movimentos/Create
        public IActionResult Create()
        {
            ViewData["Obras"] = _context.Obras.ToList();
            ViewData["Materiais"] = _context.Materiais.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraId,MaterialId,Operacao,Quantidade")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                // DataHora já definido por default no model
                _context.Add(movimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Obras"] = _context.Obras.ToList();
            ViewData["Materiais"] = _context.Materiais.ToList();
            return View(movimento);
        }
    }
}
