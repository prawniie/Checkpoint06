using System;
using System.Collections.Generic;

namespace Checkpoint_06
{
    class Program
    {
        static readonly DataAccess _dataAccess = new DataAccess();

        static void Main(string[] args)
        {
            //RecreateDatabase();

            //AddSpaceship("USS Enterprise");
            //AddSpaceship("Millennium Falcon");
            //AddSpaceship("Cylon Raider");

            //AddRavioliForSpaceship("Cylon Raider", 1, "2018-04-19");
            //AddRavioliForSpaceship("Millennium Falcon", 1, "2017-01-01");
            //AddRavioliForSpaceship("Millennium Falcon", 2, "2018-01-01");
            //AddRavioliForSpaceship("Nalle Puh", 99, "1950-01-01");

            //List<Spaceship> list = GetAllSpaceships();
            //DisplaySpaceships(list);
        }

        private static void DisplaySpaceships(List<Spaceship> list)
        {
            foreach (var spaceship in list)
            {
                Console.WriteLine(spaceship.Name);
                Console.WriteLine();
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
    }
}
