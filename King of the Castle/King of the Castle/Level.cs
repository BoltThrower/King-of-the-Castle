using King_of_the_Castle.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace King_of_the_Castle
{
    public class Level
    {
        private static Level instance;

        public PlayableCharacter King;

        public Level()
        {
            King = new PlayableCharacter(new Vector2(600, 400), "King");
        }

        public static Level Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Level();
                }
                return instance;
            }
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                King.SetFuturePosition(mousePosition);
            }

            King.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            King.Draw(spriteBatch, gameTime);
        }
    }
}
