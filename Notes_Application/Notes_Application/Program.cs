using System;
using System.Collections.Generic;

namespace Notes_Application
{

    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
    public class NoteManager
    {
        private List<Note> notes = new List<Note>();
        private int noteId = 0;

        public void CreateNote()
        {
            noteId++;
            Console.WriteLine("Enter title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            Note note = new Note()
            {
                Id = noteId,
                Title = title,
                Description = description,
                Date = DateTime.Now
            };
            notes.Add(note);
            Console.WriteLine($"Note created with Id: {note.Id}");
        }

        public void ViewNote()
        {
            Console.WriteLine("Enter note Id:");
            int id = Convert.ToInt16(Console.ReadLine());
            Note note = notes.Find(n => n.Id == id);
            if (note != null)
            {
                Console.WriteLine($"Id: {note.Id}\nTitle: {note.Title}\nDescription: {note.Description}\nDate: {note.Date}");
            }
            else
            {
                Console.WriteLine($"Note with Id {id} not found");
            }
        }

        public void ViewAllNotes()
        {
            Console.WriteLine($"{"Id",5} {"Title",-15} {"Description",-30} {"Date",20}");
            foreach (Note note in notes)
            {
                Console.WriteLine($"{note.Id,5} {note.Title,-15} {note.Description,-30} {note.Date,20}");
            }
            Console.WriteLine($"Total Notes: {notes.Count}");
        }

        public void UpdateNote()
        {
            Console.WriteLine("Enter note Id:");
            int id = Convert.ToInt16(Console.ReadLine());
            Note note = notes.Find(n => n.Id == id);
            if (note != null)
            {
                Console.WriteLine("Enter new title:");
                note.Title = Console.ReadLine();
                Console.WriteLine("Enter new description:");
                note.Description = Console.ReadLine();
                Console.WriteLine($"Note with Id {id} updated");
            }
            else
            {
                Console.WriteLine($"Note with Id {id} not found");
            }
        }

        public void DeleteNote()
        {
            Console.WriteLine("Enter note Id:");
            int id = Convert.ToInt16(Console.ReadLine());
            Note note = notes.Find(n => n.Id == id);
            if (note != null)
            {
                notes.Remove(note);
                Console.WriteLine($"Note with Id {id} deleted");
            }
            else
            {
                Console.WriteLine($"Note with Id {id} not found");
            }
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            NoteManager noteManager = new NoteManager();
            while (true)
            {
                Console.WriteLine("Choose an option:\n1. Create Note\n2. View Note\n3. View All Notes\n4. Update Note\n5. Delete Note");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        noteManager.CreateNote();
                        break;
                    case "2":
                        noteManager.ViewNote();
                        break;
                    case "3":
                        noteManager.ViewAllNotes();
                        break;
                    case "4":
                        noteManager.UpdateNote();
                        break;
                    case "5":
                        noteManager.DeleteNote();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice Entered");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}