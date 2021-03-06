﻿using GeneralUtilities;

namespace ParticleSystemLibrary
{
    public class InitialEmitterSettings
    {
        public Range<float> Life { get; }
        public Range<float> Angle { get; }
        public Range<float> Speed { get; }
        public Range<float> Size { get; }
        public Range<uint> ColorRgba { get; }
        public int ParticleTextureId { get; }

        public InitialEmitterSettings(Range<float> life, Range<float> angle, Range<float> speed, Range<float> size, Range<uint> colorRgba, int particleTextureId)
        {
            Life = life;
            Angle = angle;
            Speed = speed;
            Size = size;
            ColorRgba = colorRgba;
            ParticleTextureId = particleTextureId;
        }
    }
}