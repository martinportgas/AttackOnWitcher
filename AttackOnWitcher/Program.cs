using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackOnWitcher
{
    class Program
    {
        static void Main(string[] args)
        {
            //OnWitchAttack(5);

            List<Person> listPerson = new List<Person>();
            Person person;

            person = new Person();
            person.ageOfDeath = 10;
            person.yearOfDeath = 12;
            listPerson.Add(person);

            person = new Person();
            person.ageOfDeath = 13;
            person.yearOfDeath = 17;
            listPerson.Add(person);

            var results = OnYearOfDeath(listPerson);

            int totalKilled = 0;

            foreach (var result in results)
            {
                Console.WriteLine($"Person a born on year = {result.numberOfBornOnYear}");
                Console.WriteLine($"Number of people killed on year = {result.numberOfKilled}");
                totalKilled += result.numberOfKilled;
            }
            Console.WriteLine($"Average ({totalKilled} / {results.Count}) = {totalKilled/results.Count}");

            Console.ReadKey();
        }

        static void OnWitchAttack(int totalYear)
        {
            List<List<int>> list = new List<List<int>>();
            int TempA = 1;
            int TempB = 0;
            int TempC = 0;
            int SumKills = 0;

            for (int i = 1; i <= totalYear; i++)
            {
                TempC = TempA + TempB;
                TempA = TempB;
                TempB = TempC;
                SumKills = (TempA + TempB + TempC) - 1;

                Console.WriteLine($"Year - {i} Witch will kill {SumKills} People!");
            }

        }

        static List<PersonResult> OnYearOfDeath(List<Person> person)
        {
            var result = new List<PersonResult>();
            PersonResult resultModel;

            foreach (var row in person)
            {
                resultModel = new PersonResult();
                resultModel.numberOfBornOnYear = row.yearOfDeath - row.ageOfDeath;
                resultModel.numberOfKilled = row.yearOfDeath - row.ageOfDeath;
                result.Add(resultModel);
            }

            return result;
        }
    }
    public class Person
    {
        public string personName { get; set; }
        public int ageOfDeath { get; set; }
        public int yearOfDeath { get; set; }
    }

    public class PersonResult
    {
        public int numberOfBornOnYear { get; set; }
        public int numberOfKilled { get; set; }

    }
}
