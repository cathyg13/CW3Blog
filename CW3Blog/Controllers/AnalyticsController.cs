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
    public class AnalyticsController : Controller
    {
    
    
private readonly ApplicationDbContext _context;

        public AnalyticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnalyticsNumCommentsPerAuthor
        public async Task<IActionResult> Index()
        {
            AnalyticsListViewModel authorNumCommentsList = new AnalyticsListViewModel();

            IQueryable<AnalyticsViewModel> commentsPerAuthor =
                from analyseComment in _context.CommentModel
                group analyseComment by analyseComment.AuthorName into authorGroup
                select new AnalyticsViewModel()
                {
                    AuthorName = authorGroup.Key,
                    NumComments = authorGroup.Count()
                };

            authorNumCommentsList.AuthorCountList = await commentsPerAuthor.AsNoTracking().ToListAsync();
            return View(authorNumCommentsList.AuthorCountList);
            //return View(await _context.AnalyticsViewModel.ToListAsync());
        }

        private bool AnalyticsViewModelExists(int id)
        {
            return _context.AnalyticsViewModel.Any(e => e.ID == id);
        }
    }
}
