using Financeiro_TN.Models;
using Financeiro_TN.Repositories.Interfaces;
using Financeiro_TN.Services;
using Financeiro_TN.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Financeiro_TN.Controllers
{
    public class HomeController : Controller
    {
        private readonly INFRepository _nfRepository;
        private readonly DashboardService _dashboardService;
        public HomeController(INFRepository nfRepository, DashboardService dashboardService)
        {
            _nfRepository = nfRepository;
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                NFs = _nfRepository.NFs
            };

            return View(homeViewModel);
        }

        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> ObterDadosFiltradosDashboard(string mes, string trimestre, string ano)
        {
            var dashboardData = await _dashboardService.ObterDadosFiltrados(mes, trimestre, ano);
            return  PartialView("~/Views/Shared/Components/Dashboard/Default.cshtml", dashboardData);
        }
    }
}
