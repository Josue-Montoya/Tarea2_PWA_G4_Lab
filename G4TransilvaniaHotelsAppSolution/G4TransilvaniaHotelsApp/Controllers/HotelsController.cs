using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace G4TransilvaniaHotelsApp.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelsRepository _hotelsRepository;

        public HotelsController(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        public ActionResult Index()
        {
            return View(_hotelsRepository.GetAllHotels());
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelsModel hotel)
        {
            try
            {
                _hotelsRepository.AddHotels(hotel);
                return RedirectToAction("Index");
            }
			catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(hotel);
            }
        }

		[HttpGet]
		public ActionResult Edit(int id)
		{
            HotelsModel hotel = _hotelsRepository.GetAllHotels().FirstOrDefault(hotel => hotel.hotelId == id);

            if (hotel == null)
            {
                return NotFound();
            }

			return View(hotel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(HotelsModel hotel)
		{
			try
			{
				_hotelsRepository.EditHotels(hotel);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View(hotel);
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
        {
			HotelsModel hotel = _hotelsRepository.GetAllHotels().FirstOrDefault(hotel => hotel.hotelId == id);

			if (hotel == null)
			{
				return NotFound();
			}

			return View(hotel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(HotelsModel hotel)
		{
			try
			{
				_hotelsRepository.DeleteHotels(hotel.hotelId);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View(hotel);
			}
		}
	}
}
