using System;
using System.Collections.Generic;

namespace Checkpoint_06
{
    class Program
    {
        static readonly DataAccess _dataAccess = new DataAccess();

        static void Main(string[] args)
        {
            RecreateDatabase();

            AddSpaceship("USS Enterprise");
            AddSpaceship("Millennium Falcon");
            AddSpaceship("Cylon Raider");

            AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
            AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
            AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
            AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

            List<Spaceship> list = GetAllSpaceships();
            DisplaySpaceships(list);
        }

        private static void AddRavioliForSpaceship(string spaceshipName, int numberOfRaviolis, string packageDate)
        {
            bool spaceshipExists = _dataAccess.CheckIfSpaceshipExist(spaceshipName);
            if (spaceshipExists)
            {
                List<Ravioli> raviolis = _dataAccess.CreateRaviolis(numberOfRaviolis, packageDate);
                _dataAccess.AddRavioliForSpaceship(raviolis, spaceshipName);
            }

        }

        private static void DisplaySpaceships(List<Spaceship> list)
        {
            foreach (var spaceship in list)
            {
                WriteGrey(spaceship.Name);

                if (spaceship.Raviolis.Count == 0)
                    WritePurple("Slut på ravioli :(");
                else
                    PrintRaviolis(spaceship.Raviolis);

                Console.WriteLine();
            }
        }

        private static void PrintRaviolis(List<Ravioli> raviolis)
        {
            foreach (var ravioli in raviolis)
            {
                WritePurple($"Ravioli".PadRight(10) + "Packdatum:" + ravioli.PackageDate.ToShortDateString().PadRight(15) + "Bästföre:" + ravioli.BestBeforeDate.ToShortDateString());
            }
        }

        private static List<Spaceship> GetAllSpaceships()
        {
            List<Spaceship> spaceships = _dataAccess.GetAllSpaceships();
            return spaceships;
        }

        private static void AddSpaceship(string spaceshipName)
        {
            _dataAccess.AddSpaceship(spaceshipName);
        }

        private static void RecreateDatabase()
        {
            using (var context = new SpaceContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        private static void WriteGrey(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void WritePurple(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
