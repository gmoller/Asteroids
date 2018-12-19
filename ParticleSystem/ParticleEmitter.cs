using GeneralUtilities;

namespace ParticleSystemLibrary
{
    // TODO: make the attributes more extensible by possibly having a collection of IAttributes
    public class ParticleEmitter
    {
        private readonly InitialEmitterSettings _initialEmitterSettings;

        public ParticleEmitter(InitialEmitterSettings initialEmitterSettings)
        {
            _initialEmitterSettings = initialEmitterSettings;
        }

        public Particle Emit(float deltaTime)
        {
            float life = DetermineLife(_initialEmitterSettings.Life);
            float angle = DetermineAngle(_initialEmitterSettings.Angle);
            float speed = DetermineSpeed(_initialEmitterSettings.Speed);
            float size = DetermineSize(_initialEmitterSettings.Size);
            Color color = DetermineColor(_initialEmitterSettings.ColorRgba);

            var particle = new Particle(_initialEmitterSettings.Position, life, angle, speed, color, size, _initialEmitterSettings.ParticleTextureId);

            return particle;
        }

        private float DetermineLife(Range<float> life)
        {
            return RandomHelper.RandomNumber(life.Minimum, life.Maximum);
        }

        private float DetermineAngle(Range<float> angle)
        {
            return RandomHelper.RandomNumber(angle.Minimum, angle.Maximum);
        }

        private float DetermineSpeed(Range<float> speed)
        {
            return RandomHelper.RandomNumber(speed.Minimum, speed.Maximum);
        }

        private float DetermineSize(Range<float> size)
        {
            return RandomHelper.RandomNumber(size.Minimum, size.Maximum);
        }

        private Color DetermineColor(Range<uint> color)
        {
            var minColor = new Color(color.Minimum);
            var maxColor = new Color(color.Maximum);

            byte r = RandomHelper.RandomNumber(minColor.R, maxColor.R);
            byte g = RandomHelper.RandomNumber(minColor.G, maxColor.G);
            byte b = RandomHelper.RandomNumber(minColor.B, maxColor.B);
            byte a = RandomHelper.RandomNumber(minColor.A, maxColor.A);

            return new Color(r, g, b, a);
        }
    }
}