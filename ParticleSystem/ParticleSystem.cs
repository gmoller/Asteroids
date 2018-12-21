using System.Numerics;
using GeneralUtilities;

namespace ParticleSystemLibrary
{
    public class ParticleSystem
    {
        private readonly float _emissionRatePerSecond;
        private readonly ParticleEmitter _emitter;
        private Particles _particles;
        private readonly bool _continuous;
        private int _totalEmitted;

        private float _timeCounter;

        public int CurrentParticlesCount => _particles.CurrentParticlesCount;
        public int MaximumParticles => _particles.MaximumParticles;
        public bool AllParticlesEmitted => _totalEmitted >= MaximumParticles && !_continuous;
        public bool Completed => AllParticlesEmitted && CurrentParticlesCount == 0;
        public Particle FirstParticle => _particles.FirstParticle;
        public Particle LastParticle => _particles.LastParticle;

        public Particles Particles => _particles;

        public Vector2 Position
        {
            get { return _emitter.Position; }
            set { _emitter.Position = value; }
        }

        public Range<float> EmitDirection
        {
            get { return _emitter.EmitDirection; }
            set { _emitter.EmitDirection = value; }
        }

        public ParticleSystem(ParticleEmitter particleEmitter, int maximumParticles, float emissionRatePerSecond, bool continuous)
        {
            _particles = new Particles(maximumParticles);
            _emitter = particleEmitter;
            _emissionRatePerSecond = emissionRatePerSecond;
            _timeCounter = 1 / _emissionRatePerSecond; // initialize so that a particle is emitted on first call to Emit
            _continuous = continuous;
            _totalEmitted = 0;
        }

        public void Update(float deltaTime)
        {
            _particles = _particles.Update(deltaTime);
        }

        public void Emit(float deltaTime)
        {
            _timeCounter += deltaTime;

            if (TimeToEmit(_timeCounter))
            {
                Particle particle = _emitter.Emit(deltaTime);
                _particles.Add(particle);
                _timeCounter = 0;
                _totalEmitted++;
            }
        }

        private bool TimeToEmit(float timeCounter)
        {
            if (AllParticlesEmitted) return false;
            if (CurrentParticlesCount >= MaximumParticles) return false;

            return timeCounter >= 1 / _emissionRatePerSecond;
        }
    }
}