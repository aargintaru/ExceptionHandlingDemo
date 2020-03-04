using System;
using System.Linq;

namespace ExceptionHandlingDemo
{
    public class FunStatistics
    {
        private LetterCounter letterCounter;
        public FunStatistics()
        {
            letterCounter = new LetterCounter();
        }

        public void CrunchTheNumbers(Person[] persons)
        {
            foreach(var person in persons)
            {
                foreach(char c in person.FirstName)
                {
                    letterCounter.Count(c);
                }

                foreach(char c in person.LastName)
                {
                    letterCounter.Count(c);
                }
            }
        }

        public string MostFoundLetter()
        {
            return letterCounter.GetAllKeysInOrder(false).FirstOrDefault().ToString();
        }

        public void PrinAll()
        {
            Console.WriteLine("Here are the letter counts:");
            foreach(var item in letterCounter.GetAllInOrder(false))
            {
                Console.WriteLine($"Letter: {item.Key} - # {item.Value}");
            }
        }

    }
}