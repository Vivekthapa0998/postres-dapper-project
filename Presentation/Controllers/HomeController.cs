using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        
       public ActionResult Index() 
        {
            
            return View();

        }
    }
}
