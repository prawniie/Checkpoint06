using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Checkpoint_06
{
    public class DataAccess
    {
        private readonly SpaceContext _context;

        public DataAccess()
        {
            _context = new SpaceContext();
        }

        internal void AddSpaceship(string spaceshipName)
        {
            var spaceship = new Spaceship
            {
                Name = spaceshipName
            };

            _context.Spaceships.Add(spaceship);
            _context.SaveChanges();
        }

        internal List<Spaceship> GetAllSpaceships()
        {
            return _context.Spaceships.Include(x => x.Raviolis).ToList();
        }

        internal List<Ravioli> CreateRaviolis(int numberOfRaviolis, string packageDate)
        {
            List<Ravioli> raviolis = new List<Ravioli>();

            for (int i = 0; i < numberOfRaviolis; i++)
            {
                var ravioli = new Ravioli
                {
                    PackageDate = Convert.ToDateTime(packageDate),
                    BestBeforeDate = Convert.ToDateTime(packageDate).AddMonths(6).AddDays(15)
                    
                };
                raviolis.Add(ravioli);
            }

            //var basket = new Basket
            //{
            //    Name = "Oscars kundkorg",
            //    FruitInBaskets = new List<FruitInBasket>
            //    {
            //        new FruitInBasket { Fruit = nypon },
            //        new FruitInBasket { Fruit = päron},
            //    }
            //};

            //_context.Baskets.Add(basket);
            //_context.SaveChanges();

            //_context.Raviolis.AddRange(raviolis);
            //_context.SaveChanges();

            return raviolis;
        }

        internal void AddRavioliForSpaceship(List<Ravioli> raviolis, string spaceshipName)
        {
            Spaceship spaceship = _context.Spaceships.Where(x => x.Name == spaceshipName).FirstOrDefault();
            spaceship.Raviolis = raviolis;
            _context.SaveChanges();
        }
    }
}
