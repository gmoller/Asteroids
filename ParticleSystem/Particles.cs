using System.Collections;
using System.Collections.Generic;

namespace ParticleSystemLibrary
{
    public class Particles : IEnumerable<Particle>
    {
        private readonly int _maximumParticles;
        private readonly List<Particle> _particles;

        public int CurrentParticlesCount => _particles.Count;
        public int MaximumParticles => _maximumParticles;
        public Particle FirstParticle => _particles[0];
        public Particle LastParticle => _particles[CurrentParticlesCount - 1];

        public Particles(int maximumParticles)
        {
            _maximumParticles = maximumParticles;
            _particles = new List<Particle>(maximumParticles);
        }

        public void Add(Particle particle)
        {
            if (_particles.Count < _maximumParticles)
            {
                _particles.Add(particle);
            }
        }

        public Particles Update(float deltaTime)
        {
            var newParticles = new Particles(_maximumParticles);

            foreach (Particle particle in _particles)
            {
                if (particle.IsAlive)
                {
                    Particle changedParticle = particle.Update(deltaTime);
                    newParticles.Add(changedParticle);
                }
            }

            return newParticles;
        }

        public IEnumerator<Particle> GetEnumerator()
        {
            return ((IEnumerable<Particle>)_particles).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Particle>)_particles).GetEnumerator();
        }
    }
}