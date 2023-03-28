using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Interfaces;
using KaraokePartyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaraokePartyWebApp.Controllers
{
    public class KaraokeGroupController : Controller
    {
        private readonly IKaraokeGroupRepository _karaokeGroupRepository;
        public KaraokeGroupController(IKaraokeGroupRepository karaokeGroupRepository)
        {
            _karaokeGroupRepository = karaokeGroupRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<KaraokeGroup> groups = await _karaokeGroupRepository.GetAll();
            return View(groups);
        }

        public async Task<IActionResult> Detail(int id)
        {
            KaraokeGroup karaokeGroup = await _karaokeGroupRepository.GetByIdAsync(id);
            return View(karaokeGroup);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(KaraokeGroup karaokeGroup)
        {
            if (!ModelState.IsValid)
            {
                return View(karaokeGroup);
            }
            _karaokeGroupRepository.Add(karaokeGroup);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var karaokeGroup = await _karaokeGroupRepository.GetByIdAsync(id);
            if (karaokeGroup == null)
            {
                return View("Error");
            }

            return View(karaokeGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, KaraokeGroup karaokeGroup)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to Edit Club");
                return View("Edit", karaokeGroup);
            }
            var karaokeGroupEdited = new KaraokeGroup
            {
                Id = id,
                Name = karaokeGroup.Name,
                Description = karaokeGroup.Description,
                Image = karaokeGroup.Image,
                Category = karaokeGroup.Category,
            };
            _karaokeGroupRepository.Update(karaokeGroupEdited);
            return RedirectToAction("Index");

        }
    }
}
