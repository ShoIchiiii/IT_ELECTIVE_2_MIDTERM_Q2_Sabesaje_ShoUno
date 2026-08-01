using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [AuthorizeSession]
    public class PlaylistController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("UserSession");
            return View(MockDatabase.Playlists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var dto = new CreatePlaylistDto();
            dto.Videos.Add(new CreateVideoDto()); // Start with 1 empty row
            return View(dto);
        }

        [HttpPost]
        public IActionResult AddVideoRow(CreatePlaylistDto dto)
        {
            dto.Videos.Add(new CreateVideoDto());
            ModelState.Clear();
            return View("Create", dto);
        }

        [HttpPost]
        public IActionResult RemoveVideoRow(CreatePlaylistDto dto, int index)
        {
            if (index >= 0 && index < dto.Videos.Count)
            {
                dto.Videos.RemoveAt(index);
            }
            ModelState.Clear();
            return View("Create", dto);
        }

        [HttpPost]
        public IActionResult Save(CreatePlaylistDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", dto);
            }

            var playlist = new Playlist
            {
                Title = dto.Title,
                CreatorName = HttpContext.Session.GetString("UserSession") ?? "Anonymous"
            };

            foreach (var v in dto.Videos)
            {
                if (!string.IsNullOrWhiteSpace(v.YouTubeUrl))
                {
                    playlist.Videos.Add(new VideoItem { YouTubeUrl = v.YouTubeUrl, TrackNote = v.TrackNote });
                }
            }

            MockDatabase.Playlists.Add(playlist);
            return RedirectToAction("Index");
        }
    }
}