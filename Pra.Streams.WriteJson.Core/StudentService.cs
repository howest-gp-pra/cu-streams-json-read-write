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
            students = new List<Student>();
            students.Add(new Student("Janssens", "Jan", "Brugge"));
            students.Add(new Student("Willems", "Wim", "Brugge"));
            students.Add(new Student("Kaerels", "Charel", "Brugge"));
            students.Add(new Student("Taer", "Guy", "Brugge"));
            students.Add(new Student("Banjo", "Lien", "Brugge"));
            students.Add(new Student("Tumas", "Marie", "Brugge"));
        }

        public void WriteJson()
        {
            var content = JsonConvert.SerializeObject(students);
            File.WriteAllText(Environment.CurrentDirectory + "\\students.json", content);
        }
    }
}
