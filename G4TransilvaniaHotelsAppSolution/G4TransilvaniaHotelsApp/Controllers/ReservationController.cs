using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.Repositories;
using G4TransilvaniaHotelsApp.RepositoriesClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace G4TransilvaniaHotelsApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository, IHotelsRepository hotelsRepository, IClientRepository clientRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _hotelsRepository = hotelsRepository;
            _clientRepository = clientRepository;
            _roomRepository = roomRepository;
        }

        public IActionResult ViewReservation()
        {
            return View(_reservationRepository.GetAllReservations());
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            var hotels = _hotelsRepository.GetAllHotels();
            var clients = _clientRepository.GetAll();
            var rooms = _roomRepository.RoomsGetAll();
            ViewBag.Hotels = new SelectList(hotels, nameof(HotelsModel.hotelId), nameof(HotelsModel.hotelName));
            ViewBag.Client = new SelectList(clients, nameof(ClientModel.clientId), nameof(ClientModel.clientName));
            ViewBag.Room = new SelectList(rooms, nameof(RoomModel.ID), nameof(RoomModel.roomNumber));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateReservation(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.AddReservation(reservation);

                return RedirectToAction(nameof(ViewReservation));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;

                return View(reservation);
            }
        }

        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            var hotels = _hotelsRepository.GetAllHotels();
            var clients = _clientRepository.GetAll();
            var rooms = _roomRepository.RoomsGetAll();
            ViewBag.Hotels = new SelectList(hotels, nameof(HotelsModel.hotelId), nameof(HotelsModel.hotelName));
            ViewBag.Client = new SelectList(clients, nameof(ClientModel.clientId), nameof(ClientModel.clientName));
            ViewBag.Room = new SelectList(rooms, nameof(RoomModel.ID), nameof(RoomModel.roomNumber));

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditReservation(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.EditReservation(reservation); 

                return RedirectToAction(nameof(ViewReservation));
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;

                return View(reservation);
            }
        }

        [HttpGet]
        public ActionResult DeleteReservation(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReservation(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.DeleteReservation(reservation.reservationId);
                return RedirectToAction(nameof(ViewReservation));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(reservation);
            }
        }
    }
    


}
