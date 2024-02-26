using FluentValidation;
using FluentValidation.Results;
using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.Repositories;
using G4TransilvaniaHotelsApp.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace G4TransilvaniaHotelsApp.Controllers
{
    public class HotelsController : Controller
    {
        private IValidator<HotelsModel> _hotelsValidator;
        private readonly IHotelsRepository _hotelsRepository;

        public HotelsController(IHotelsRepository hotelsRepository, IValidator<HotelsModel> hotelsValidator)
        {
            _hotelsValidator = hotelsValidator;
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
			ValidationResult validationResult = _hotelsValidator.Validate(hotel);  

            try
            {
                _hotelsRepository.AddHotels(hotel);
                return RedirectToAction("Index");
            }
			catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

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
