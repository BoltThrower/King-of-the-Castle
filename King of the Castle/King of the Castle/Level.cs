using King_of_the_Castle.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace King_of_the_Castle
{
    public class Level
    {
        private static Level instance;

        public PlayableCharacter King;

        public List<PlayableCharacter> PlayableCharacters;
        public List<Enemy> Enemies;

        public Level()
        {
            King = new PlayableCharacter(new Vector2(630, 400), "King");

            PlayableCharacters = new List<PlayableCharacter>();
            Enemies = new List<Enemy>();

            BuildLevel();
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

        public void BuildLevel()
        {
            PlayableCharacters.Add(new PlayableCharacter(new Vector2(575, 400), "TownGuard"));

            Enemies.Add(new Enemy(new Vector2(650, 550), "Bandit"));
        }

        public void Update(GameTime gameTime)
        {
            King.Update(gameTime);

            foreach(PlayableCharacter pc in PlayableCharacters)
            {
                pc.Update(gameTime);
            }

            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch, gameTime);
            }

            foreach (PlayableCharacter pc in PlayableCharacters)
            {
                pc.Draw(spriteBatch, gameTime);
            }

            King.Draw(spriteBatch, gameTime);
        }
    }
}
