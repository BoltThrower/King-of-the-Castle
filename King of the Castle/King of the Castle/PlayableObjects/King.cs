using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using King_of_the_Castle.Interfaces;

namespace King_of_the_Castle.GameObjects
{
    public class King : IPlayableObjectState
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        private IPlayableObject parent;
        private AnimatedSprite sprite;


        public King(IPlayableObject playableObject)
        {
            this.parent = playableObject;
            this.Position = parent.Position;

            sprite = AnimatedSpriteFactory.Instance.BuildKingSprite(parent.Position);
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
