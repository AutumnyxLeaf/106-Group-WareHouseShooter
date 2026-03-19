/// Tommy B, Ethan C, Ian H, Autumn S
/// 3/6/26
/// Our legendary game :)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Right_to_Return_Arms
{
    // Game state enum

    public enum GameState
    {
        Title,
        Pause,
        ItemPickup,
        GameOver,
        HighScores,
        Game
    }
    
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        // Keeping track of Finite state machine
        private GameState _gameState;
        // Previous mouse state
        private MouseState _previousMouseState;

        // Temporary UI variables that can be moved to manager later
        
        // Title Screen vars
        Button _startBut;
        Button _closeGameBut;
        Button _highscoresBut;

        // Pause Screen vars
        Button _resumeBut;
        Button _menuBut; // Menu Button will likely be reused;

        // Game Over vars
        // Will have the return to menu button
        // Will have the highscores button
        // Retry button at some point??

        // High Scores vars
        // Will have the menu button

        // End of temporary variables

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Creating buttons
            _startBut = new Button(350, 100, Content.Load<Texture2D>("Start Button"));
            _highscoresBut = new Button(350, 200, Content.Load<Texture2D>("Highscore Button"));
            _closeGameBut = new Button(350, 300, Content.Load<Texture2D>("Exit Button"));
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Finite state machine, can be moved to manager later
            MouseState ms = Mouse.GetState();
            switch (_gameState)
            {
                case GameState.Title:
                    if (_startBut.mouseIntersects(ms) && SingleMouseClick())
                    {
                        _gameState = GameState.Game;
                    }
                    else if(_highscoresBut.mouseIntersects(ms) && SingleMouseClick())
                    {
                        _gameState = GameState.HighScores;
                    }
                    else if (_closeGameBut.mouseIntersects(ms) && SingleMouseClick())
                    {
                        Exit();
                    }
                        break;
                case GameState.Pause:

                    break;
                case GameState.ItemPickup:

                    break;
                case GameState.GameOver:

                    break;
                case GameState.HighScores:

                    break;
                case GameState.Game:

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Likely to be moved into 
            switch (_gameState)
            {
                case GameState.Title:
                    _startBut.Draw(_spriteBatch);
                    _closeGameBut.Draw(_spriteBatch);
                    _highscoresBut.Draw(_spriteBatch);
                    break;
                case GameState.Pause:

                    break;
                case GameState.ItemPickup:

                    break;
                case GameState.GameOver:

                    break;
                case GameState.HighScores:

                    break;
                case GameState.Game:

                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Helper method to check if the mouse has been pressed for a single turn
        /// </summary>
        /// <returns></returns>
        private bool SingleMouseClick()
        {
            return (Mouse.GetState().LeftButton == ButtonState.Pressed) && 
                _previousMouseState.LeftButton == ButtonState.Released;
        }

    }
}
