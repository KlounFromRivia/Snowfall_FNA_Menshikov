using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace SnowFall_FNA_Menshikov
{
    public class Snowfall : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Graphics;
        SpriteBatch PaintScreen;
        Random rnd = new Random();
        Texture2D fon;
        Texture2D snow;
        int speed = 0;
        public List<Snows> Snowflakes = new List<Snows>();
        private KeyboardState keyboardState = Keyboard.GetState();
        private KeyboardState keyboardState2;

        public Snowfall()
        {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferredBackBufferWidth = 1024;
            Graphics.PreferredBackBufferHeight = 768;
            AddCreateSnow();
            Content.RootDirectory = "Content";
        }

        public void AddCreateSnow()
        {
            for (int i = 0; i < 2200; i++)
            {
                Snowflakes.Add(new Snows
                {
                    X = rnd.Next(Graphics.PreferredBackBufferWidth),
                    Y = -rnd.Next(Graphics.PreferredBackBufferHeight),
                    Size = rnd.Next(5, 15),

                });
            }
        }

        protected override void LoadContent()
        {
            PaintScreen = new SpriteBatch(GraphicsDevice);
            fon = Content.Load<Texture2D>("..\\snowPole.jpg");
            snow = Content.Load<Texture2D>("..\\pngwing.com.png");
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState2 = keyboardState;
            keyboardState = Keyboard.GetState();

            foreach (var snowflake in Snowflakes)
            {
                if (snowflake.Size > 11)
                {
                    speed = 5;
                    snowflake.Y += speed;
                }
                else if (snowflake.Size > 7)
                {
                    speed = 3;
                    snowflake.Y += speed;
                }
                else
                {
                    speed = 1;
                    snowflake.Y += speed;
                }
                if (snowflake.Y > Graphics.PreferredBackBufferHeight)
                {
                    snowflake.Y = -rnd.Next(0, 50);
                    snowflake.X = rnd.Next(0, Graphics.PreferredBackBufferWidth);
                }
            }

            if (keyboardState2.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            PaintScreen.Begin();
            PaintScreen.Draw(fon, new Rectangle(0, 0, Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight), Color.LightYellow);
            foreach (var snowflake in Snowflakes)
            {
                PaintScreen.Draw(snow, new Rectangle(snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size), Color.White);
            }
            PaintScreen.End();
        }
    }
}
