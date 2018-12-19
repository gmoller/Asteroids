using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonogameUtilities
{
    public class KeyboardHandler
    {
        private KeyboardState _previousState;
        private KeyboardState _currentState;

        public KeyboardHandler()
        {
            _previousState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return _currentState.IsKeyDown(key);
        }

        public bool IsKeyPressed(Keys key)
        {
            return _currentState.IsKeyDown(key) && !_previousState.IsKeyDown(key);
        }
    }
}