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
        // Previous Keyboard state
        private KeyboardState _previousKeyboardState;

        // Temporary UI variables that can be moved to manager later
        
        // Title Screen vars
        Button _startBut;
        Button _closeGameBut;
        Button _highscoresBut;

        // Pause Screen vars
        Button _menuBut; // Menu Button will likely be reused;

        // Game Over vars
        // Will have the return to menu button
        // Will have the highscores button
        // Retry button at some point??

        // High Scores vars
        // Will have the menu button

        // End of temporary variables


        // Player stuff
        Player player;

        // Managers
        BulletManager bulletManager;

        Texture2D bulletSprite;


        GameObject wall;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            bulletManager = new BulletManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Creating buttons
            _startBut = new Button(350, 100, Content.Load<Texture2D>("Start Button"));
            _highscoresBut = new Button(350, 200, Content.Load<Texture2D>("Highscore Button"));
            _closeGameBut = new Button(350, 300, Content.Load<Texture2D>("Exit Button"));
            _menuBut = new Button(50, 50, Content.Load<Texture2D>("Menu Button"));


            // Player stuff
            player = new Player(Content.Load<Texture2D>("Start Button"), new Rectangle(100, 100, 50, 50), CollisionTags.Player);
            player.Speed = 5;

            bulletSprite = Content.Load<Texture2D>("Menu Button");

            wall = new GameObject(Content.Load<Texture2D>("Highscore Button"), new Rectangle(300, 0, 10, 400), CollisionTags.Wall);

        }

        protected override void Update(GameTime gameTime)
        {
            // Finite state machine, can be moved to manager later
            MouseState ms = Mouse.GetState();
            KeyboardState kb = Keyboard.GetState();
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
                    if (_menuBut.mouseIntersects(ms) && SingleMouseClick())
                    {
                        _gameState = GameState.Title;
                    }
                    else if (SingleKeyPress(Keys.Escape))
                    {
                        _gameState = GameState.Game;
                    }
                        break;
                case GameState.ItemPickup:

                    break;
                case GameState.GameOver:

                    break;
                case GameState.HighScores:
                    if(_menuBut.mouseIntersects(ms) && SingleMouseClick())
                    {
                        _gameState = GameState.Title;
                    }
                    break;
                case GameState.Game:
                    if (SingleKeyPress(Keys.Escape))
                    {
                        _gameState = GameState.Pause;
                    }

                    // Player stuff
                    player.Update();

                    if (SingleMouseClick())
                    {
                        bulletManager.AddBullet(new Bullet(bulletSprite, new Rectangle(player.transform.Location.X, player.transform.Location.Y, 10, 10)));
                        bulletManager.GetLastBullet().VelocityDirection = new Vector2(ms.Position.X - player.transform.X, ms.Position.Y - player.transform.Y);
                        bulletManager.GetLastBullet().Velocity *= 3;
                    }

                    wall.Update();
                    bulletManager.UpdateBullets();
                    bulletManager.CheckBulletCollisons(wall, CollisionTags.Wall);

                    break;
            }
            _previousMouseState = ms;
            _previousKeyboardState = kb;

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
                    // Overlaying dark screen
                    player.Draw(_spriteBatch);
                    wall.Draw(_spriteBatch);
                    bulletManager.DrawBullets(_spriteBatch);
                    _spriteBatch.Draw(Content.Load<Texture2D>("Transparent Black Screen"),
                        new Vector2(0, 0), Color.White);
                    _menuBut.Draw(_spriteBatch);
                    break;
                case GameState.ItemPickup:

                    break;
                case GameState.GameOver:

                    break;
                case GameState.HighScores:
                    _menuBut.Draw(_spriteBatch);
                    break;
                case GameState.Game:
                    player.Draw(_spriteBatch);
                    wall.Draw(_spriteBatch);
                    bulletManager.DrawBullets(_spriteBatch);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Helper method to check if the mouse has been pressed for a single turn
        /// </summary>
        /// <returns>True if the mouse was pressed onnce, false otherwise</returns>
        private bool SingleMouseClick()
        {
            return (Mouse.GetState().LeftButton == ButtonState.Pressed) && 
                _previousMouseState.LeftButton == ButtonState.Released;
        }

        /// <summary>
        /// Helper method to see if a key was pressed once and not held
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the key was pressed once, false otherwise</returns>
        private bool SingleKeyPress(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
        }

    }
}
