using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreProject.Models;
namespace NetCoreProject.Controllers
{
    public class ClientController : Controller
    {
        private static List<ClientViewModels> Cars = new List<ClientViewModels> ()
        {
            new ClientViewModels
            {
                Name = "Gonzalo",
                Lastname = "Rodriguez",
                Age = 22
            },
            new ClientViewModels
            {
                Name = "Hernan",
                Lastname = "Pereira",
                Age = 11
            },
        };
// GET: Client
        public IActionResult Index()
        {
            return View(Clients);
        }
    }
}