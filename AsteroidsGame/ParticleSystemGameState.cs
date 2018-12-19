using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AsteroidsGame.Renderers;
using GeneralUtilities;
using MonogameUtilities;
using ParticleSystemLibrary;

namespace AsteroidsGame
{
    public class ParticleSystemGameState : IGameState
    {
        private ParticleSystem _particleSystem1;
        private ParticleSystem _particleSystem2;

        private Label _label1;
        private Label _label2;

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager content)
        {
            var spriteFont = content.Load<SpriteFont>("ArialFont");
            _label1 = new Label(spriteFont);
            _label2 = new Label(spriteFont);

            var particleTexture = content.Load<Texture2D>("particle");
            int particleTextureId = TextureManager.Add(particleTexture);

            var emitter1 = new ParticleEmitter(new InitialEmitterSettings(
                new System.Numerics.Vector2(600, 400),
                new Range<float>(1.0f, 10.0f),
                new Range<float>(0.0f, 360.0f),
                new Range<float>(25.0f, 80.0f),
                new Range<float>(0.1f, 10f),
                new Range<uint>(new Microsoft.Xna.Framework.Color(205, 0, 0, 255).PackedValue, new Microsoft.Xna.Framework.Color(255, 100, 25, 255).PackedValue), // red-ish
                particleTextureId));
            _particleSystem1 = new ParticleSystem(emitter1, 100, 60.0f, true); // 60 per second

            var emitter2 = new ParticleEmitter(new InitialEmitterSettings(
                new System.Numerics.Vector2(100, 600),
                new Range<float>(1.0f, 1.0f),
                new Range<float>(89.0f, 91.0f),
                new Range<float>(1000.0f, 1025.0f),
                new Range<float>(0.1f, 0.5f),
                new Range<uint>(Microsoft.Xna.Framework.Color.Cyan.PackedValue),
                particleTextureId));
            _particleSystem2 = new ParticleSystem(emitter2, 100, 60.0f, false); // 60 per second
        }

        public void Update(GameTime gameTime)
        {
            _particleSystem1.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            //_particleSystem2.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            _particleSystem1.Emit((float)gameTime.ElapsedGameTime.TotalSeconds);
            //_particleSystem2.Emit((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            ParticleSystemRenderer.Draw(spriteBatch, _particleSystem1.Particles);
            //ParticleSystemRenderer.Draw(spriteBatch, _particleSystem2.Particles);

            spriteBatch.End();

            _label1.Draw(spriteBatch, $"Particles 1: {_particleSystem1.CurrentParticlesCount}/{_particleSystem1.MaximumParticles}", new Vector2(1, 25));
            _label2.Draw(spriteBatch, $"Particles 2: {_particleSystem2.CurrentParticlesCount}/{_particleSystem2.MaximumParticles}", new Vector2(1, 50));
        }
    }
}