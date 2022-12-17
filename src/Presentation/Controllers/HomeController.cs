using Application;
using Application.BaseObjects;
using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : KernelControllerBase
    {
        public HomeController(Mediator mediator)
        {
            MediatR = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Person(string id)
        {
            ViewBag.Message = "Your person page.";

            return View(await MediatR.Send(new PersonQuery(id)));
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";

            return View(await MediatR.Send(new PersonsQuery()));

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}