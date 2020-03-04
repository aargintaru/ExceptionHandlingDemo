using System;
using System.Collections.Generic;
using System.IO;

namespace ExceptionHandlingDemo
{
    public class TxtFileHandler : IFileHandler
    {
        private readonly string filePath;
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public TxtFileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public Person[] ReadData()
        {
            try
            {
                log.Debug($"Start reading data from {filePath}");
                string[] linesRead = File.ReadAllLines(filePath);
                log.Debug($"Finished reading data from {filePath}");
                var result = ParseLines(linesRead);
                return result;
            }
            catch(Exception ex)
            {
                throw new MyCustomException($"An error occured when reading data from file: {filePath}", ex);
            }
        }

        private Person[] ParseLines(string[] input)
        {
            log.Info("Parsing lines read from file...");
            List<Person> persons = new List<Person>();
            foreach(var line in input)
            {
                var splitLine = line.Split(',');
                var person = new Person();
                person.FirstName = splitLine[0].Trim();
                person.LastName = splitLine[1].Trim();
                person.Age = splitLine[2].Trim();
                log.Debug($"Added person with the following details: FirstName={person.FirstName}, LastName={person.LastName}, Age={person.Age}");
                persons.Add(person);
            }
            return persons.ToArray();
        }
    }
}