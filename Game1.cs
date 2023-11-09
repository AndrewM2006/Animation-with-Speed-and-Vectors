using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Reflection.Emit;

namespace Animation_with_Speed_and_Vectors
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTexture;
        Texture2D brownTexture1;
        Texture2D brownTexture2;
        Texture2D creamTexture;
        Texture2D orangeTexture;
        Texture2D LoraxBG;
        Rectangle greyRect;
        Rectangle brownRect1;
        Rectangle brownRect2;
        Rectangle creamRect;
        Rectangle orangeRect;
        Vector2 greySpeed;
        Vector2 brownSpeed;
        Vector2 creamSpeed;
        Vector2 orangeSpeed;
        byte red = 255, green = 255, blue = 255;
        Color randomColor;
        Song coo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.ApplyChanges();
            this.Window.Title = "Moving Textures";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random generator = new Random();
            greyRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth-100), generator.Next(_graphics.PreferredBackBufferHeight-100), 100, 100);
            brownRect1 = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            brownRect2 = new Rectangle(_graphics.PreferredBackBufferWidth+100, 0, 100, 100);
            creamRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            orangeRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
            greySpeed = new Vector2(2, 4);
            brownSpeed = new Vector2(4, 0);
            creamSpeed = new Vector2(0, 4);
            orangeSpeed = new Vector2(4, 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTexture1 = Content.Load<Texture2D>("tribbleBrown");
            brownTexture2 = Content.Load<Texture2D>("tribbleBrown");
            creamTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTexture = Content.Load<Texture2D>("tribbleOrange");
            LoraxBG = Content.Load<Texture2D>("Lorax");
            this.coo = Content.Load<Song>("tribble_coo");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Random generator = new Random();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyRect.X += (int)greySpeed.X;
            greyRect.Y += (int)greySpeed.Y;
            brownRect1.X += (int)brownSpeed.X;
            brownRect2.X += (int)brownSpeed.X;
            creamRect.Y += (int)creamSpeed.Y;
            orangeRect.X += (int)orangeSpeed.X;
            orangeRect.Y += (int)orangeSpeed.Y;
            if (greyRect.Right > _graphics.PreferredBackBufferWidth || greyRect.Left < 0)
            {
                greySpeed.X *= -1;
                red = Convert.ToByte(generator.Next(256)); blue = Convert.ToByte(generator.Next(256)); green = Convert.ToByte(generator.Next(256));
                randomColor = new Color (red, green, blue);
                MediaPlayer.Play(coo);
            }
            if (greyRect.Bottom > _graphics.PreferredBackBufferHeight || greyRect.Top < 0)
            {
                greySpeed.Y *= -1;
                red = Convert.ToByte(generator.Next(256)); blue = Convert.ToByte(generator.Next(256)); green = Convert.ToByte(generator.Next(256));
                randomColor = new Color(red, green, blue);
                MediaPlayer.Play(coo);
            }
            if (orangeRect.Right > _graphics.PreferredBackBufferWidth || orangeRect.Left < 0)
            {
                orangeRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
                do
                {
                    orangeSpeed = new Vector2(generator.Next(-5, 5), generator.Next(-5, 5));
                } while (orangeSpeed.X == 0 && orangeSpeed.Y == 0);
                MediaPlayer.Play(coo);
            }
            if (orangeRect.Bottom > _graphics.PreferredBackBufferHeight || orangeRect.Top < 0)
            {
                orangeRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
                do
                {
                    orangeSpeed = new Vector2(generator.Next(-5, 5), generator.Next(-5, 5));
                } while (orangeSpeed.X == 0 && orangeSpeed.Y == 0);
                MediaPlayer.Play(coo);
            }
            if (creamRect.Bottom > _graphics.PreferredBackBufferHeight ||  creamRect.Top < 0)
            {
                creamSpeed.Y *= -1;
                creamRect = new Rectangle(creamRect.Left, creamRect.Top, generator.Next(50, 150), 100);
                MediaPlayer.Play(coo);
            }
            if (brownRect1.Right > _graphics.PreferredBackBufferWidth && brownRect1.Right <= _graphics.PreferredBackBufferWidth + brownSpeed.X)
            {
                brownRect2 = new Rectangle(-100, brownRect1.Top, 100, 100);
                MediaPlayer.Play(coo);
            }
            else if (brownRect2.Right > _graphics.PreferredBackBufferWidth && brownRect2.Right <= _graphics.PreferredBackBufferWidth + brownSpeed.X)
            {
                brownRect1 = new Rectangle(-100, brownRect2.Top, 100, 100);
                MediaPlayer.Play(coo);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(LoraxBG, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            _spriteBatch.Draw(greyTexture, greyRect, randomColor);
            _spriteBatch.Draw(brownTexture1, brownRect1, Color.White);
            _spriteBatch.Draw(brownTexture2, brownRect2, Color.White);
            _spriteBatch.Draw(creamTexture, creamRect, Color.White);
            _spriteBatch.Draw(orangeTexture, orangeRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}