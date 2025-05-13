using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_TecnicaTest.Models;
using CRUD_TecnicaTest.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD_TecnicaTest.Controllers;

public class HomeController : Controller
{
    private IUnitOfWork _UnitOfWork;

    public HomeController(IUnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    

    public async Task<IActionResult> GetGenericT()
    {
        var ResponseFromRepository_GetAll = await _UnitOfWork._UnitOfWork_Lavadora.GeAlll();
        if (!ResponseFromRepository_GetAll.Any())
            return RedirectToAction("Privacy", "Home");

        return View("Index", ResponseFromRepository_GetAll);
    }

    public async Task<IActionResult> AddGenericT(Lavadora t)
    {
        var ResponseFromRepository_Add = await _UnitOfWork._UnitOfWork_Lavadora.AddAsnyc(t);
            if (!ResponseFromRepository_Add){
                return RedirectToAction("Privacy", "Home");
            }
                return View("Index");
    }

    public async Task<IActionResult> DeleteById(int IdLavadora)
    {
        var ResponseFromRepository_DeleteById = await _UnitOfWork._UnitOfWork_Lavadora.DeleteById(IdLavadora);

        if (!ResponseFromRepository_DeleteById)
            return RedirectToAction("Privacy", "Home");

        return View("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
