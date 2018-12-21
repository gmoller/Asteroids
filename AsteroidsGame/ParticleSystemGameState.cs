using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using AsteroidsGame.Renderers;
using AsteroidsGameLibrary;
using MonogameUtilities;
using ParticleSystemLibrary;

namespace AsteroidsGame
{
    public class ParticleSystemGameState : IGameState
    {
        private ParticleSystem _particleSystem1;

        private Label _label1;

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager content)
        {
            var spriteFont = content.Load<SpriteFont>("ArialFont");
            _label1 = new Label(spriteFont);

            var particleTexture = content.Load<Texture2D>("particle");
            int particleTextureId = TextureManager.Add(particleTexture);

            var emitter = EmitterPrefabs.Engine(new System.Numerics.Vector2(GameSettings.Resolution.X / 2 + 50.0f, GameSettings.Resolution.Y / 2), particleTextureId);

            _particleSystem1 = new ParticleSystem(emitter, 100, 20.0f, false); // 60 per second
        }

        public void Update(GameTime gameTime)
        {
            _particleSystem1.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            _particleSystem1.Emit((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            ParticleSystemRenderer.Draw(spriteBatch, _particleSystem1);

            spriteBatch.End();

            _label1.Draw(spriteBatch, $"Particles 1: {_particleSystem1.CurrentParticlesCount}/{_particleSystem1.MaximumParticles}", new Vector2(1, 25));
        }
    }
}