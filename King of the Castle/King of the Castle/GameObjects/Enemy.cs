using King_of_the_Castle.Enemies;
using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.GameObjects
{
    public class Enemy : IEnemy
    {
        public Vector2 Position { get; set; }
        public Vector2 FuturePosition { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public IEnemyState EnemyState { get; set; }

        public Enemy(Vector2 position, string enemyState)
        {
            Position = position;
            FuturePosition = position;  // make the unit not move when spawned.
            Velocity = new Vector2(1f, 1f);

            if (enemyState == "Bandit")
            {
                EnemyState = new Bandit(this);
            }
        }

        public void SetFuturePosition(Vector2 futurePos)
        {
        }

        public void Update(GameTime gameTime)
        {
            EnemyState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            EnemyState.Draw(spriteBatch, gameTime);
        }
    }
}
