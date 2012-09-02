using System.Linq;
using System.Web.Mvc;
using RoachHotel.Mvc.Models;
using RoachHotel.Mvc.Models.Data;

namespace RoachHotel.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Item> _itemRepository;

        public HomeController()
        {
            _itemRepository = new Repository<Item>();    
        }
        
        public ActionResult Index()
        {
            var items = _itemRepository.GetAll().ToList();

            return View(items);
        }
    }
}
