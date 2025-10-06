using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dwc.Data;
using dwc.Models;
using System.Threading.Tasks;

namespace dwc.Controllers
{
    public class RegistosPagamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistosPagamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistoPagamento
        public async Task<IActionResult> Index()
        {
            var pagamentos = await _context.RegistosPagamentos
                .Include(p => p.Obra)
                .ToListAsync();
            return View(pagamentos);
        }

        // GET: RegistoPagamento/Create
        public IActionResult Create()
        {
            ViewData["Obras"] = _context.Obras.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObraId,NomePessoa,Valor")] RegistoPagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                // DataHora já definido por default se tiveres no model
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Obras"] = _context.Obras.ToList();
            return View(pagamento);
        }
    }
}
