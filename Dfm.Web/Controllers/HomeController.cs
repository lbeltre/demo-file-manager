using Dfm.Core.UoW;
using Dfm.Web.Code;
using Dfm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dfm.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string contentRoot = "content_root";
        private const string identifierTreeRoot = "#";

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
            return View();
        }

        public IActionResult FolderCreate(string name)
        {
            return View("Index");
        }

        public IActionResult GetData(string id)
        {
            var isRoot = id == identifierTreeRoot;
            var search = isRoot ? RootPath : $"{RootPath}{id}";
            var models = unitOfWork.GetTree(search);

            ITreeClientAdapter adapter = new TreeClientAdapter(models, RootPath);
            return Json(isRoot ? adapter.GetRoot() : adapter.GetChilds());
        }

        public IActionResult GetContent(string id)
        {
            var isRoot = id == identifierTreeRoot;
            var search = isRoot ? RootPath : $"{RootPath}{id}";
            var models = unitOfWork.GetTree(search);

            ITreeClientAdapter adapter = new TreeClientAdapter(models, RootPath);
            return Json(adapter.GetChilds(true));
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


        //TODO
        /*
         * get only txt
         * implement crud UI         
         */
    }
}