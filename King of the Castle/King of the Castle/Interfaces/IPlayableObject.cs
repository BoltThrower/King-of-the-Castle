﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.Interfaces
{
    public interface IPlayableObject
    {
        Vector2 Position { get; set; }
        Vector2 FuturePosition { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle CollisionRectangle { get; set; }

        IPlayableObjectState PlayableObjectState { get; set; }
        bool IsSelected { get; set; }

        void SetFuturePosition(Vector2 futurePos);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
