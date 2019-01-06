using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW3Blog.Data;
using CW3Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CW3Blog.Controllers
{
    [Authorize(Roles = "RAdmin")]
    public class AnalyticsLocationController : Controller
    {


        private readonly ApplicationDbContext _context;

        public AnalyticsLocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnalyticsLocation
        public async Task<IActionResult> Index()
        {
            IQueryable<AnalyticsLocationViewModel> userLocations =
                 from analyseLocation in _context.User
                 group analyseLocation by analyseLocation.Location into locationGroup
                 select new AnalyticsLocationViewModel()
                 {
                     Location = locationGroup.Key,
                     NumUsers = locationGroup.Count()
                 };

            return View(await userLocations.AsNoTracking().ToListAsync());
        }

        private bool AnalyticsLocationViewModelExists(int id)
        {
            return _context.AnalyticsLocationViewModel.Any(e => e.ID == id);
        }
    }
}
