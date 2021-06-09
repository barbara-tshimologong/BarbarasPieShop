using BarbarasPieShop.Repositories;
using BarbarasPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbarasPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public ViewResult List()
        {
            PieListViewModel pieListViewModel = new();
            pieListViewModel.Pies = _pieRepository.AllPies;
            pieListViewModel.CurrentCategory = "Cheese Cakes";

            return View(pieListViewModel);
        }
    }
}
