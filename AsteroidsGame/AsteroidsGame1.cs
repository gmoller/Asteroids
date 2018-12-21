using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AsteroidsGameLibrary;
using GeneralUtilities;
using MonogameUtilities;

namespace AsteroidsGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class AsteroidsGame1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private IGameState _gameState1;
        private IGameState _gameState2;

        private SpriteFont _spriteFont;

        private readonly FrameCounter _frameCounter = new FrameCounter();
        private Label _fpsLabel;

        public AsteroidsGame1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
            graphics.SynchronizeWithVerticalRetrace = false;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameSettings.Resolution = new System.Numerics.Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            _gameState1 = new MainGameState();
            _gameState1.Initialize();

            _gameState2 = new ParticleSystemGameState();
            _gameState2.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteFont = Content.Load<SpriteFont>("ArialFont");
            //_spriteFontAnton = Content.Load<SpriteFont>("AntonFont20");
            _fpsLabel = new Label(_spriteFont);

            _gameState1.LoadContent(Content);
            _gameState2.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _gameState1.Update(gameTime);
            _gameState2.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(GameSettings.BackgroundColor.PackedValue));

            _fpsLabel.Draw(spriteBatch, $"FPS: {_frameCounter.AverageFramesPerSecond}", new Vector2(1, 1));

            _gameState1.Draw(spriteBatch);
            _gameState2.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}