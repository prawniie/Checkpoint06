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
    }
}
