using System;

namespace ExceptionHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileHandler fileHandler = new TxtFileHandler("Persons.txt");
            Person[] persons = fileHandler.ReadData();
            foreach(var person in persons)
            {
                Console.WriteLine($"{person.FirstName} - {person.LastName} of age: {person.Age}");
            }
            
            FunStatistics stats = new FunStatistics();
            stats.CrunchTheNumbers(persons);
            Console.WriteLine($"Most found letter in the names: {stats.MostFoundLetter()}");
            stats.PrinAll();
        }
    }
}
