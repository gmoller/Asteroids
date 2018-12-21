using System.Numerics;
using GeneralUtilities;

namespace ParticleSystemLibrary
{
    public static class EmitterPrefabs
    {
        public static ParticleEmitter Engine(Vector2 position, int particleTextureId)
        {
            var emitter = new ParticleEmitter(position, new InitialEmitterSettings(
                new Range<float>(0.2f, 0.2f),
                new Range<float>(-15.0f, 15.0f),
                new Range<float>(15.0f, 20.0f),
                new Range<float>(1.5f, 1.8f),
                new Range<uint>(Color.Orange.PackedValue, Color.Red.PackedValue),
                particleTextureId));

            return emitter;
        }

        public static ParticleEmitter Fireball(Vector2 position, int particleTextureId)
        {
            var emitter = new ParticleEmitter(position, new InitialEmitterSettings(
                new Range<float>(1.0f, 1.0f),
                new Range<float>(0.0f, 360.0f),
                new Range<float>(25.0f, 80.0f),
                new Range<float>(0.1f, 10f),
                new Range<uint>(Color.DarkRed.PackedValue, Color.OrangeRed.PackedValue),
                particleTextureId));

            return emitter;
        }
    }
}