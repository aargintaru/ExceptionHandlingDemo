using System.Collections.Generic;
using System.IO;

namespace ExceptionHandlingDemo
{
    public class TxtFileHandler : IFileHandler
    {
        private readonly string filePath;

        public TxtFileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public Person[] ReadData()
        {
            var linesRead = File.ReadAllLines(filePath);
            return ParseLines(linesRead);
        }

        private Person[] ParseLines(string[] input)
        {
            List<Person> persons = new List<Person>();
            foreach(var line in input)
            {
                var splitLine = line.Split(',');
                var person = new Person();
                person.FirstName = splitLine[0].Trim();
                person.LastName = splitLine[1].Trim();
                person.Age = splitLine[2].Trim();
                persons.Add(person);
            }
            return persons.ToArray();
        }
    }
}