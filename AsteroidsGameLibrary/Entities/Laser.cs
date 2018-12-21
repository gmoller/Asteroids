using System.Numerics;
using CollisionDetectionLibrary;
using GeneralUtilities;
using ParticleSystemLibrary;
using ShapesLibrary;

namespace AsteroidsGameLibrary.Entities
{
    public class Laser
    {
        private readonly Vector2 _positionOffset; // position of hard point relative to center of parent (spaceship) facing north
        private readonly Color _color;
        private bool _isFiring;
        private ParticleSystem _laserParticleSystem;

        private readonly int _particleTextureId;

        public bool IsFiring => _isFiring;
        public bool CanShoot => !_isFiring;
        public ParticleSystem LaserParticleSystem => _laserParticleSystem;

        public CollisionBoundary CollisionBoundary
        {
            get
            {
                if (_isFiring && _laserParticleSystem.CurrentParticlesCount > 0)
                {
                    Shape shape = new LineSegment(_laserParticleSystem.FirstParticle.Position.X, _laserParticleSystem.FirstParticle.Position.Y,
                                                  _laserParticleSystem.LastParticle.Position.X, _laserParticleSystem.LastParticle.Position.Y);
                    return new CollisionBoundary(shape);
                }

                return new CollisionBoundary(new LineSegment(0, 0, 0, 0));
                //return new NullCollisionBoundary();
            }
        }

        public Laser(Vector2 positionOffset, Color color, int particleTextureId)
        {
            _positionOffset = positionOffset;
            _color = color;
            _particleTextureId = particleTextureId;
            _isFiring = false;
        }

        public void Shoot(Vector2 parentPosition, float parentRotationInRadians)
        {
            if (!_isFiring)
            {
                Vector2 turretPosition = parentPosition + _positionOffset;
                turretPosition = turretPosition.RotateAroundPoint(parentPosition, parentRotationInRadians);

                var emitter = new ParticleEmitter(turretPosition, new InitialEmitterSettings(
                    new Range<float>(0.5f, 0.5f),
                    new Range<float>(parentRotationInRadians.ToDegrees()),
                    new Range<float>(2000.0f, 2500.0f),
                    new Range<float>(0.1f, 1.0f),
                    new Range<uint>(_color.PackedValue),
                    _particleTextureId));
                _laserParticleSystem = new ParticleSystem(emitter, 10, 600.0f, false); // 600 per second

                _isFiring = true;
            }
        }

        public void Remove()
        {
            _isFiring = false;
        }

        public void Update(float deltaTime)
        {
            if (_isFiring)
            {
                _laserParticleSystem.Update(deltaTime);
                _laserParticleSystem.Emit(deltaTime);

                _isFiring = !_laserParticleSystem.Completed;
            }
        }
    }
}