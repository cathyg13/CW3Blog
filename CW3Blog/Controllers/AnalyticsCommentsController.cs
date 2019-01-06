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
    public class AnalyticsCommentsController : Controller
    {
    
    
private readonly ApplicationDbContext _context;

        public AnalyticsCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnalyticsNumCommentsPerAuthor
        public async Task<IActionResult> Index()
        {
            IQueryable<AnalyticsCommentsViewModel> commentsPerAuthor =
                from analyseComment in _context.CommentModel
                group analyseComment by analyseComment.AuthorName into authorGroup
                select new AnalyticsCommentsViewModel()
                {
                    AuthorName = authorGroup.Key,
                    NumComments = authorGroup.Count()
                };

            return View(await commentsPerAuthor.AsNoTracking().ToListAsync());
        }

        private bool AnalyticsViewModelExists(int id)
        {
            return _context.AnalyticsViewModel.Any(e => e.ID == id);
        }
    }
}
