using System.Numerics;
using AsteroidsGameLibrary.Entities;
using GeneralUtilities;
using ParticleSystemLibrary;

namespace AsteroidsGameLibrary
{
    public class SpaceShipEngine
    {
        private readonly SpaceShip _parent;
        private readonly int _particleTextureId;
        private bool _engineStarted;
        private ParticleSystem _engine;
        private readonly Vector2 _positionOffset; // position of engine relative to center of parent (spaceship) facing north

        public bool EngineStarted => _engineStarted;
        public ParticleSystem Engine => _engine;

        public SpaceShipEngine(SpaceShip parent, int particleTextureId)
        {
            _parent = parent;
            _particleTextureId = particleTextureId;
            _positionOffset = new Vector2(0.0f, _parent.Size.X / 2.0f + 10.0f);
        }

        public void Start(Vector2 position)
        {
            _engineStarted = true;
            var emitter = EmitterPrefabs.Engine(position, _particleTextureId);
            _engine = new ParticleSystem(emitter, 100, 20.0f, false);
        }

        public void Update(float deltaTime)
        {
            if (_engineStarted)
            {
                Vector2 enginePosition = _parent.Position + _positionOffset;
                float angle = -_parent.MotionVectorCurrent.ToAngleAsRadians();
                _engine.Position = enginePosition.RotateAroundPoint(_parent.Position, _parent.RotationInRadians);
                _engine.EmitDirection = new Range<float>(angle - 0, angle + 0);
                _engine.Update(deltaTime);
                _engine.Emit(deltaTime);

                if (_engine.AllParticlesEmitted)
                {
                    _engineStarted = false;
                }
            }
        }
    }
}