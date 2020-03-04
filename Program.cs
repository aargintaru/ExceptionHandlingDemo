using System;
using NLog;

namespace ExceptionHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logFile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logConsole");
            NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
            NLog.LogManager.Configuration = config;

            IFileHandler fileHandler = new TxtFileHandler("Persons.txt");
            try
            {
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
            catch (MyCustomException ex)
            {
                log.Error($"Exception message: {ex.Message}, Stacktrace: {ex.StackTrace}, ");
            }
        }
    }
}
