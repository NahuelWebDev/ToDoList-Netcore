using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public interface INoteService
    {
        public List<Note> getNotes();

        public Note getNote(String id);

        public void insertNote(string contenuto);
        void deleteNote(int id);
    }
}
