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
        public PlayableCharacter TownGuard1;
        public Enemy Bandit;

        public Level()
        {
            King = new PlayableCharacter(new Vector2(630, 400), "King");
            TownGuard1 = new PlayableCharacter(new Vector2(575, 400), "TownGuard");
            Bandit = new Enemy(new Vector2(650, 550), "Bandit");
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
            King.Update(gameTime);
            TownGuard1.Update(gameTime);
            Bandit.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Bandit.Draw(spriteBatch, gameTime);
            TownGuard1.Draw(spriteBatch, gameTime);
            King.Draw(spriteBatch, gameTime);
        }
    }
}
