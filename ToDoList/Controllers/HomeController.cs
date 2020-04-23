using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private INoteService note;
        public HomeController(ILogger<HomeController> logger, INoteService note)
        {
            _logger = logger;
            this.note = note;
        }

        public IActionResult Index(int id = 0)
        {
            List<Note> listNotes = this.note.getNotes();
            return View(listNotes);
        }

        [HttpPost]
        public IActionResult Index(string NoteEdit)
        {
            this.note.insertNote(NoteEdit);
            List<Note> listNotes = this.note.getNotes();
            return View(listNotes);
        }

        public RedirectToActionResult Delete(int id)
        {
            this.note.deleteNote(id);
            List<Note> listNotes = this.note.getNotes();
            return RedirectToAction("Index", "Home");
        }
    }
}
