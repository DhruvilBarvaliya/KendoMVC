using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Repositorise.Interfaces;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private UserInterface _userInterface;
        public AdminController(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Tasks()
        {
            var users = await _userInterface.GetAllTask();
            return Ok(users);
        }
    }
}