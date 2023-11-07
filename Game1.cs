using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Emit;

namespace Animation_with_Speed_and_Vectors
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTexture;
        Texture2D brownTexture;
        Texture2D creamTexture;
        Texture2D orangeTexture;
        Texture2D LoraxBG;
        Rectangle greyRect;
        Rectangle brownRect;
        Rectangle creamRect;
        Rectangle orangeRect;
        Vector2 greySpeed;
        Vector2 brownSpeed;
        Vector2 creamSpeed;
        Vector2 orangeSpeed;

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
            brownRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
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
            brownTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTexture = Content.Load<Texture2D>("tribbleCream");
            orangeTexture = Content.Load<Texture2D>("tribbleOrange");
            LoraxBG = Content.Load<Texture2D>("Lorax");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Random generator = new Random();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyRect.X += (int)greySpeed.X;
            greyRect.Y += (int)greySpeed.Y;
            brownRect.X += (int)brownSpeed.X;
            creamRect.Y += (int)creamSpeed.Y;
            orangeRect.X += (int)orangeSpeed.X;
            orangeRect.Y += (int)orangeSpeed.Y;
            if (greyRect.Right > _graphics.PreferredBackBufferWidth || greyRect.Left < 0)
            {
                greySpeed.X *= -1;
            }
            if (greyRect.Bottom > _graphics.PreferredBackBufferHeight || greyRect.Top < 0)
            {
                greySpeed.Y *= -1;
            }
            if (orangeRect.Right > _graphics.PreferredBackBufferWidth || orangeRect.Left < 0)
            {
                orangeRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
                orangeSpeed = new Vector2 (generator.Next (-5, 5), generator.Next (-5, 5));
            }
            if (orangeRect.Bottom > _graphics.PreferredBackBufferHeight || orangeRect.Top < 0)
            {
                orangeRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 100), generator.Next(_graphics.PreferredBackBufferHeight - 100), 100, 100);
                orangeSpeed = new Vector2(generator.Next(-5, 5), generator.Next(-5, 5));
            }
            if (creamRect.Bottom > _graphics.PreferredBackBufferHeight ||  creamRect.Top < 0)
            {
                creamSpeed.Y *= -1;
            }
            if (brownRect.Right > _graphics.PreferredBackBufferWidth ||  brownRect.Left < 0)
            {
                brownSpeed.X *= -1;
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
            _spriteBatch.Draw(greyTexture, greyRect, Color.White);
            _spriteBatch.Draw(brownTexture, brownRect, Color.White);
            _spriteBatch.Draw(creamTexture, creamRect, Color.White);
            _spriteBatch.Draw(orangeTexture, orangeRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}