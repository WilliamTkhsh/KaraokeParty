using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Interfaces;
using KaraokePartyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaraokePartyWebApp.Controllers
{
    public class KaraokeClubController : Controller
    {
        private readonly IKaraokeClubRepository _karaokeClubRepository;
        public KaraokeClubController(IKaraokeClubRepository karaokeClubRepository)
        {
            _karaokeClubRepository = karaokeClubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<KaraokeClub> clubs = await _karaokeClubRepository.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            KaraokeClub club = await _karaokeClubRepository.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(KaraokeClub club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }
            _karaokeClubRepository.Add(club);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _karaokeClubRepository.GetByIdAsync(id);
            if (club == null)
            {
                return View("Error");
            }

            return View(club);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, KaraokeClub club)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to Edit Club");
                return View("Edit", club);
            }
            var clubEdited = new KaraokeClub
            {
                Id = id,
                Name = club.Name,
                Description = club.Description,
                Image = club.Image,
                Address = club.Address,
                AddressId = club.AddressId,
                Category = club.Category,
            };
            _karaokeClubRepository.Update(clubEdited);
            return RedirectToAction("Index");
            
        }
    }
}
