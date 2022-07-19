using Dfm.Core.UoW;
using Dfm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dfm.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string contentRoot = "content_root";

        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IUnitOfWork unitOfWork;

        public string RootPath => Path.Combine(webHostEnvironment.WebRootPath, contentRoot);

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            CreateRootSpace();
            var root = unitOfWork.GetTree(RootPath);
            return View(root);
        }

        public IActionResult FolderCreate(string name)
        {


            return View("Index");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CreateRootSpace()
        {
            if (!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);
        }
    }
}