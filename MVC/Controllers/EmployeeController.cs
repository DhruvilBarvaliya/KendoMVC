using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.Repositorise.Interfaces;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private UserInterface _userInterface;
        public EmployeeController(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(t_Employee employee)
        {
            if (employee.c_empformFile != null && employee.c_empformFile.Length > 0)
            {
                var fileName = employee.c_empEmail + Path.GetExtension(employee.c_empformFile.FileName);
                var filePath = Path.Combine("../TaskTrackPro.MVC/wwwroot/profile_images", fileName);
                employee.c_empProfile = fileName;
                using var stream = new FileStream(filePath, FileMode.Create);
                await employee.c_empformFile.CopyToAsync(stream);
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(employee.c_empPwd);

            

             _userInterface.Add(employee);
            return RedirectToAction("Index");
        }
    }
}