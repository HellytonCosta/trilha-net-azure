using Microsoft.AspNetCore.Mvc;

namespace trilha_net_azure.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
