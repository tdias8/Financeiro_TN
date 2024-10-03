using Financeiro_TN.Models;
using Financeiro_TN.Repositories.Interfaces;
using Financeiro_TN.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financeiro_TN.Controllers
{
    public class NFController : Controller
    {
        private readonly INFRepository _NFRepository;

        public NFController(INFRepository nFRepository)
        {
            _NFRepository = nFRepository;
        }

        public IActionResult List()
        {
            var nfViewModel = new NFViewModel();
            nfViewModel.NFs = _NFRepository.NFs;

            return View(nfViewModel);

        }
    }
}
