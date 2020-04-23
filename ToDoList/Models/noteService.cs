using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class noteService : INoteService
    {
        private DbAccessor db;

        public noteService (DbAccessor db)
        {
            this.db = db;
        }

        public void deleteNote(int id)
        {
            var query = "DELETE from Note where id = @id";
            db.delete(query,id);
        }

        public Note getNote(string id)
        {
            throw new NotImplementedException();
        }

        public List<Note> getNotes()
        {
            var listNotes = new List<Note>();
            Note note;
            var query = "SELECT * FROM Note";
            DataSet dataset = db.query(query);
            var dataTable = dataset.Tables[0];
            foreach(DataRow row in dataTable.Rows)
            {
                note = new Note();
                note.contenuto = (string)row["contenuto"];
                note.id = (int)row["id"];
                listNotes.Add(note);
            }
                return listNotes;
        }

        public void insertNote(string contenuto)
        {
            var query = "insert into note (contenuto) values (@contenuto)";
            db.insert(query,contenuto);
        }
    }
}
