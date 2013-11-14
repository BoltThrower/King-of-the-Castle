using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.Interfaces
{
    public interface IHand
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle CollisionRectangle { get; set; }
        bool IsRight { get; set; }
        bool IsActive { get; set; }

        IHandState HandState { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
