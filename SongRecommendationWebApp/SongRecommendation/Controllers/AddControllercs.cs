using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation.Controllers
{
    public class AddControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
