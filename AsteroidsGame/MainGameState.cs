using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using AsteroidsGameLibrary;
using AsteroidsGameLibrary.Entities;
using AsteroidsGame.Renderers;
using MonogameUtilities;

namespace AsteroidsGame
{
    public class MainGameState : IGameState
    {
        private KeyboardHandler _keyboard;

        private Hud _hud;
        private SpaceShip _spaceShip;
        private Asteroids _asteroids;

        public void Initialize()
        {
            _keyboard = new KeyboardHandler();
        }

        public void LoadContent(ContentManager content)
        {
            var particleTexture = content.Load<Texture2D>("particle");
            int particleTextureId = TextureManager.Add(particleTexture);

            var spaceShipTexture = content.Load<Texture2D>("Spaceship");
            int spaceShipTextureId = TextureManager.Add(spaceShipTexture);

            var spriteFont = content.Load<SpriteFont>("AntonFont20");
            int spriteFontId = SpriteFontManager.Add(spriteFont);

            _hud = new Hud(spriteFontId);
            _spaceShip = new SpaceShip(new System.Numerics.Vector2(GameSettings.Resolution.X / 2, GameSettings.Resolution.Y / 2), 0.0f, spaceShipTextureId, particleTextureId);
            _asteroids = AsteroidsCreator.CreateAsteroids(10);
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _hud.ScoreLabel = new AsteroidsGameLibrary.Controls.Label(new System.Numerics.Vector2(GameSettings.Resolution.X * Constants.ONE_THIRD, 0.0f), $"Score: {GameSettings.Score:00000}", AsteroidsGameLibrary.Controls.HorizontalAlignment.Center);
            _hud.LivesLabel = new AsteroidsGameLibrary.Controls.Label(new System.Numerics.Vector2(GameSettings.Resolution.X * Constants.TWO_THIRDS, 0.0f), $"Lives: {GameSettings.Lives:0}", AsteroidsGameLibrary.Controls.HorizontalAlignment.Center);

            _keyboard.Update(gameTime);

            HandleInput(deltaTime);

            DoCollisionDetection();

            _spaceShip.Update(deltaTime);
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid?.Update(deltaTime);
            }
        }

        private void HandleInput(float deltaTime)
        {
            if (_keyboard.IsKeyDown(Keys.A))
            {
                _spaceShip.RotateLeft(6.0f * deltaTime);
            }
            if (_keyboard.IsKeyDown(Keys.D))
            {
                _spaceShip.RotateRight(6.0f * deltaTime);
            }
            if (_keyboard.IsKeyDown(Keys.W))
            {
                _spaceShip.IncreaseThrust(100.0f * deltaTime);
            }
            if (_keyboard.IsKeyDown(Keys.S))
            {
                //_spaceShip.DecreaseThrust(50.0f * deltaTime);
            }
            if (_keyboard.IsKeyPressed(Keys.Space))
            {
                _spaceShip.ShootGun();
            }
        }

        private void DoCollisionDetection()
        {
            var newAsteroids = new Asteroids();
            var backgroundColor = new GeneralUtilities.Color(Color.Black.PackedValue);
            foreach (Asteroid asteroid in _asteroids)
            {
                bool addToList = true;
                if (CollisionChecker.IsColliding(_spaceShip, asteroid))
                {
                    backgroundColor = new GeneralUtilities.Color(Color.Magenta.PackedValue);
                }

                foreach (Laser laser in _spaceShip.Lasers)
                {
                    if (CollisionChecker.IsColliding(laser, asteroid))
                    {
                        bool destroy = AsteroidShot(asteroid, laser);
                        addToList = !destroy;
                    }
                }

                if (addToList)
                {
                    newAsteroids.Add(asteroid);
                }
            }

            GameSettings.BackgroundColor = backgroundColor;
            _asteroids = newAsteroids;
        }

        private bool AsteroidShot(Asteroid asteroid, Laser laser)
        {
            bool destroy = asteroid.AsteroidHit();
            laser.Remove();

            if (destroy)
            {
                GameSettings.Score++;
            }

            return destroy;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HudRenderer.Draw(spriteBatch, _hud);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            SpaceShipRenderer.Draw(spriteBatch, _spaceShip);
            foreach (Asteroid asteroid in _asteroids)
            {
                AsteroidRenderer.Draw(spriteBatch, asteroid);
            }

            spriteBatch.End();
        }
    }
}