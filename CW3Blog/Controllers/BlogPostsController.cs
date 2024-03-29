﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW3Blog.Data;
using CW3Blog.Models;
using Microsoft.AspNetCore.Authorization;
using CW3Blog.ViewModels;
using System.Collections.Generic;

namespace CW3Blog.Controllers
{

    public class BlogPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogPostModel.ToListAsync());
        }

        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPostModel blogPostModel = await _context.BlogPostModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            BlogPostCommentsViewModel viewModel = await GetBlogPostCommentsViewModelFromBlogPost(blogPostModel);

            return View(viewModel);
        }

        private async Task<BlogPostCommentsViewModel> GetBlogPostCommentsViewModelFromBlogPost(BlogPostModel blogPost)
         {

            BlogPostCommentsViewModel viewModel = new BlogPostCommentsViewModel();

            viewModel.BlogPost = blogPost;

            List<CommentModel> comments = await _context.CommentModel
                .Where(x => x.BlogPost == blogPost).ToListAsync();

            viewModel.Comments = comments;

            return viewModel;
         }

        // GET: BlogPosts/Create
        [Authorize(Roles = "RAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "RAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,AuthorName,CreatedTime,Content")] BlogPostModel blogPostModel)
        {

            if (ModelState.IsValid)
            {
                _context.Add(blogPostModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPostModel);
        }

        // POST: BlogPosts/Details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("BlogPostID,AuthorName,CreatedTime,Content")] BlogPostCommentsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CommentModel comment = new CommentModel();

                comment.AuthorName = viewModel.AuthorName;
                comment.CreatedTime = viewModel.CreatedTime;
                comment.Content = viewModel.Content;

                BlogPostModel blogPost = await _context.BlogPostModel
                    .SingleOrDefaultAsync(m => m.ID == viewModel.BlogPostID);

                if (blogPost == null)
                {
                    return NotFound();
                }

                comment.BlogPost = blogPost;
                _context.CommentModel.Add(comment);
                await _context.SaveChangesAsync();

                viewModel = await GetBlogPostCommentsViewModelFromBlogPost(blogPost);
            }
            return View(viewModel);
        }


        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "RAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPostModel = await _context.BlogPostModel.SingleOrDefaultAsync(m => m.ID == id);
            if (blogPostModel == null)
            {
                return NotFound();
            }
            return View(blogPostModel);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "RAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,AuthorName,CreatedTime,Content")] BlogPostModel blogPostModel)
        {
            if (id != blogPostModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPostModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostModelExists(blogPostModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPostModel);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "RAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPostModel = await _context.BlogPostModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            return View(blogPostModel);
        }

        // POST: BlogPosts/Delete/5
        [Authorize(Roles = "RAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPostModel = await _context.BlogPostModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.BlogPostModel.Remove(blogPostModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostModelExists(int id)
        {
            return _context.BlogPostModel.Any(e => e.ID == id);
        }
    }
}
