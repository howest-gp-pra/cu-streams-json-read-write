using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Pra.Streams.WriteJson.Core
{
    public class StudentService
    {
        private List<Student> students;

        public List<Student> Students
        {
            get { return students; }
        }

        public StudentService()
        {
            string path = Environment.CurrentDirectory;
            GetStudents();
        }
        private void GetStudents()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\students.json"))
                ReadJson();
            else
                DoSeeding();

        }
        private void ReadJson()
        {
            var content = File.ReadAllText(Environment.CurrentDirectory + "\\students.json");
            students = JsonConvert.DeserializeObject<List<Student>>(content);

        }
        private void DoSeeding()
        {
            students = new List<Student>
            {
                new Student("Janssens", "Jan", "Brugge"),
                new Student("Willems", "Wim", "Brugge"),
                new Student("Kaerels", "Charel", "Brugge"),
                new Student("Taer", "Guy", "Brugge"),
                new Student("Banjo", "Lien", "Brugge"),
                new Student("Tumas", "Marie", "Brugge")
            };
        }

        public void WriteJson()
        {
            string content = JsonConvert.SerializeObject(students);
            File.WriteAllText(Environment.CurrentDirectory + "\\students.json", content);
        }
    }
}
