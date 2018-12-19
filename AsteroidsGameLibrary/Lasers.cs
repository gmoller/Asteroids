using System.Collections;
using System.Collections.Generic;
using AsteroidsGameLibrary.Entities;

namespace AsteroidsGameLibrary
{
    public class Lasers : IEnumerable<Laser>
    {
        private readonly List<Laser> _lasers;

        public int Count => _lasers.Count;

        public Lasers()
        {
            _lasers = new List<Laser>();
        }

        public void Add(Laser laser)
        {
            _lasers.Add(laser);
        }

        public IEnumerator<Laser> GetEnumerator()
        {
            return ((IEnumerable<Laser>)_lasers).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Laser>)_lasers).GetEnumerator();
        }
    }
}