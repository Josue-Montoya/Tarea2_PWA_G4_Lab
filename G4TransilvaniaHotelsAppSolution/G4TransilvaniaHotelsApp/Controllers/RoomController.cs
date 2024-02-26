using Microsoft.AspNetCore.Mvc;
using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation;
using FluentValidation.Results;
using G4TransilvaniaHotelsApp.Validations;

namespace G4TransilvaniaHotelsApp.Controllers
{
    public class RoomController : Controller
    {
        private IValidator<RoomModel> _roomValidator;

        private readonly IRoomRepository _roomRepository;
        private readonly IHotelsRepository _hotelsRepository;

        public RoomController(IRoomRepository roomRepository, IHotelsRepository hotelsRepository, IValidator<RoomModel> roomValidator)
        {
            _roomValidator = roomValidator;
            _roomRepository = roomRepository;
            _hotelsRepository = hotelsRepository;
        }

        public IActionResult ViewRoom()
        {
            return View(_roomRepository.RoomsGetAll());
        }

        [HttpGet]

        public IActionResult CreateRoom() 
        {
            var hotels = _hotelsRepository.GetAllHotels();
            ViewBag.Hotels = new SelectList(hotels, nameof(HotelsModel.hotelId), nameof(HotelsModel.hotelName));
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateRoom(RoomModel room)
        {
            ValidationResult validationResult = _roomValidator.Validate(room);

            try
            {
                _roomRepository.AddRoom(room);

                return RedirectToAction(nameof(ViewRoom));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;

                validationResult.AddToModelState(this.ModelState);

                return View(room);
            }
        }

        [HttpGet]
        public IActionResult EditRoom(int id)
        {
            
            var room = _roomRepository.GetRoomById(id);
            var hotels = _hotelsRepository.GetAllHotels();
            ViewBag.Hotels = new SelectList(hotels, nameof(HotelsModel.hotelId), nameof(HotelsModel.hotelName));

            if (room == null)
            {
                return NotFound(); 
            }

            return View(room); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(RoomModel room)
        {
            try
            {
                _roomRepository.EditRoom(room); // Actualizar la habitación

                return RedirectToAction(nameof(ViewRoom));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;

                return View(room);
            }
        }


        [HttpGet]
        public ActionResult DeleteRoom(int id)
        {
            var room = _roomRepository.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoom(RoomModel room)
        {
            try
            {
                _roomRepository.DeleteRoom(room.ID);
                return RedirectToAction(nameof(ViewRoom));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(room);
            }
        }

    }
}
