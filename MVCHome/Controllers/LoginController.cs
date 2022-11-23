using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHome.Context;
using System;
using System.Linq;

namespace MVCHome.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult LoginUser(string user, string password)
        //{
        //    try
        //    {
        //        var response = _context.UsuarioDb.Where(u => u.User == user && u.Password == password).ToList();
        //        if (response.Count > 0)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }catch(Exception e)
        //    {
        //        throw new Exception("Surgio un error: " + e.Message);
        //    }
        //}

        [HttpPost]
        public JsonResult LoginUser(string user, string password)
        {
            try
            {
                var response = _context.Usuario.Include(x=>x.Rol).
                    FirstOrDefault(u => u.User == user && u.Password == password);
                if (response != null)
                {
                    if (response.Rol.Nombre == "administrador")
                    {
                        return Json(new { Success = true, admin = true });
                    }
                    else
                    {
                        return Json(new { Success = true, admin = false });
                    }
                }
                return Json(new { Success = false, admin = false });
                
            }
            catch (Exception e)
            {
                throw new Exception("Surgio un error: " + e.Message);
            }
        }
    }
}
