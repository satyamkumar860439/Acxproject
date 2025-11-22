using Microsoft.AspNetCore.Mvc;

namespace Acxproject.Controllers
{
    public class mainController:Controller
    {


        public IActionResult Dashboard()
        {
           
            return View();
        }
    }
}
