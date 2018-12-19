using System;
using System.Numerics;
using GeneralUtilities;

namespace ParticleSystemLibrary
{
    public struct Particle
    {
        private readonly Vector2 _position;
        private readonly Vector2 _velocity;
        private readonly float _life; // lifespan of particle in seconds

        public Color Color { get; }
        public float Size { get; }
        public int TextureId { get; }

        public Vector2 Position => _position;
        public bool IsAlive => _life > 0.0f;

        public Particle(Vector2 position, float life, float angleInDegrees, float speed, Color color, float size, int textureId)
        {
            TextureId = textureId;
            _position = position;
            _life = life;
            float angleInRadians = angleInDegrees.ToRadians();

            float velocityX = (float)(Math.Sin(angleInRadians) * speed);
            float velocityY = (float)(-Math.Cos(angleInRadians) * speed);

            _velocity = new Vector2(velocityX, velocityY);
            Color = color;
            Size = size;
        }

        private Particle(Vector2 position, float life, Vector2 velocity, Color color, float size, int textureId)
        {
            TextureId = textureId;
            _position = position;
            _life = life;
            _velocity = velocity;
            Color = color;
            Size = size;
        }

        public Particle Update(float deltaTime)
        {
            float life = _life - deltaTime;

            if (IsAlive)
            {
                float x = _position.X + _velocity.X * deltaTime;
                float y = _position.Y + _velocity.Y * deltaTime;

                return new Particle(new Vector2(x, y), life, _velocity, Color, Size, TextureId);
            }

            return new Particle(_position, life, _velocity, Color, Size, TextureId);
        }
    }
}