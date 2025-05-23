using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameMergeGitYZTA 
{
    public class Game2 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _pixelTexture;

        private Vector2 _squarePosition;
        private Color _squareColor = Color.CornflowerBlue; 
        private int _squareSize = 100;

        private Vector2 _circlePosition;
        private Color _circleColor = Color.IndianRed;
        private int _circleRadius = 30;

        public Game2()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _squarePosition = new Vector2(
                _graphics.PreferredBackBufferWidth / 2 - _squareSize / 2,
                _graphics.PreferredBackBufferHeight / 2 - _squareSize / 2
            );  

            _circlePosition = new Vector2(
                _squarePosition.X + _squareSize + 20, 
                _squarePosition.Y + (_squareSize / 2) - _circleRadius 
            );

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pixelTexture = Content.Load<Texture2D>("pixel");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray); 

            _spriteBatch.Begin();

            _spriteBatch.Draw(
                _pixelTexture,
                new Rectangle(
                    (int)_squarePosition.X,
                    (int)_squarePosition.Y,
                    _squareSize,
                    _squareSize),
                _squareColor
            );


            _spriteBatch.Draw(
                _pixelTexture,
                new Rectangle(
                    (int)_circlePosition.X,
                    (int)_circlePosition.Y,
                    _circleRadius * 2, 
                    _circleRadius * 2),
                _circleColor
            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}