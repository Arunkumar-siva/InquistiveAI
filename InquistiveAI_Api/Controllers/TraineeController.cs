using Microsoft.AspNetCore.Mvc;
using InquistiveAI_Library;
namespace InquistiveAI_Api.Controllers
{
    public class TraineeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
