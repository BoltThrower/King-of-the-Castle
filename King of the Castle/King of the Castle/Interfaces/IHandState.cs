﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.Interfaces
{
    public interface IHandState
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle CollisionRectangle { get; set; }
        bool IsRight { get; set; }
        bool IsFirstFrame { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
