using System.Linq;
using System.Web.Mvc;
using RoachHotel.Mvc.Models;
using RoachHotel.Mvc.Models.Data;

namespace RoachHotel.Mvc.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemsController()
        {
            _itemRepository = new Repository<Item>();
        }

        public ActionResult Details(int id)
        {
            var model = _itemRepository.Get(i => i.Id == id);

            return View(model.ToList());
        }

        //[HttpPost]
        //public ActionResult Items(Item[] models)
        //{
        //    foreach (var model in models)
        //    {
        //        model.s
        //    }

        //    _itemRepository.SaveOrUpdateAll();

        //    return View(models.ToList());
        //}
    }
}
