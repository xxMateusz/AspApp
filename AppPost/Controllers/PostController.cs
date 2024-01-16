using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppPost.Models;

namespace AppPost.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
       
        
            private readonly IPostService _postService;

            public PostController(IPostService postService)
            {
                _postService = postService;
            }

            [AllowAnonymous]
            public IActionResult Index()
            {
            //var posts = _postService.FindAll();
            //return View(posts);
            return View(_postService.FindAll());
        }


            [HttpGet]
            public IActionResult Create()
            {
                Post model = new Post();
                return View(model);
            }

        [HttpPost]
        public IActionResult Create(Post post)
        {
           
            if (ModelState.IsValid)
            {
                _postService.Add(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }


        [HttpGet]
            public IActionResult Update(int id)
            {
                var post = _postService.FindById(id);
                if (post != null)
                {
                    return View(post);
                }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult Update(Post model)
            {
                if (ModelState.IsValid)
                {
                    _postService.Update(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                var post = _postService.FindById(id);
                if (post != null)
                {
                    return View(post);
                }
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                var post = _postService.FindById(id);
                if (post != null)
                {
                    _postService.Delete(post.Id);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }
    }

