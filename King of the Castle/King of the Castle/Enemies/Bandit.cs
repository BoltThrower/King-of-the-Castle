using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using King_of_the_Castle.Interfaces;

namespace King_of_the_Castle.Enemies
{
    public class Bandit : IEnemyState
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        private IEnemy parent;
        private AnimatedSprite sprite;


        public Bandit(IEnemy enemyObject)
        {
            this.parent = enemyObject;
            this.Position = parent.Position;

            sprite = AnimatedSpriteFactory.Instance.BuildBanditSprite(parent.Position);
            this.CollisionRectangle = sprite.SpriteDestinationRectangle;
        }

        public void Update(GameTime gameTime)
        {
            this.Position = parent.Position;
            sprite.UpdateSpritePosition(Position);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            sprite.Draw(spriteBatch, gameTime);
        }
    }
}
