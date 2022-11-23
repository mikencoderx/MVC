using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCHome.Context;
using MVCHome.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MVCHome.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-KVO21IJ; Initial Catalog=MVC-24BM; Integrated Security=True;");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //var response = await _context.ArticuloDb.ToListAsync();
                var response = await connection.QueryAsync<Articulo>("MostrarArticulos", new { }, commandType: CommandType.StoredProcedure);
                return View(response);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }

        

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Articulo response)
        {
            try
            {
                await connection.QueryAsync<Articulo>("InsertarArticulo",
                    new { response.Nombre, response.Descripcion, response.UrlImg }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Editar(Articulo response)
        {
            try
            {
                await connection.QueryAsync<Articulo>("ModificarArticulo",
                    new { response.PkArticulo, response.Nombre, response.Descripcion, response.UrlImg }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }
    }
}
