using Microsoft.AspNetCore.Mvc;
using G4TransilvaniaHotelsApp.Data;
using G4TransilvaniaHotelsApp.Models;
using G4TransilvaniaHotelsApp.RepositoriesClient;

namespace G4TransilvaniaHotelsApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ActionResult Index()
        {
            return View(_clientRepository.GetAll());  ;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientModel client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            _clientRepository.add(client);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var client = _clientRepository.GetClientByclientId(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientModel client)
        {
            try
            {
                _clientRepository.Edit(client);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(client);

            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = _clientRepository.GetClientByclientId(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ClientModel client)
        {
            try
            {
                _clientRepository.Delete(client.clientId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(client);

            }

        }

    }
}
