using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using King_of_the_Castle.Interfaces;
using King_of_the_Castle.GameObjects;
using System;

namespace King_of_the_Castle
{
    public class PlayableCharacter : IPlayableObject
    {
        public Vector2 Position { get; set; }
        public Vector2 FuturePosition { get; set; }
        public Vector2 Velocity { get; set; }

        public bool IsSelected { get; set; }

        public IPlayableObjectState PlayableObjectState { get; set; }

        public PlayableCharacter(Vector2 position, string characterState)
        {
            Position = position;
            Velocity = new Vector2(1f, 1f);

            IsSelected = true;

            if (characterState == "King")
            {
                PlayableObjectState = new King(this);
            }
        }

        public void Move()
        {
            // Change X Coordinate
            if(Position.X == Math.Abs(FuturePosition.X))
            {
                Position = new Vector2(FuturePosition.X, Position.Y);
            }

            else if (Position.X < FuturePosition.X)
            {
                Position = new Vector2(Position.X + Velocity.X, Position.Y);
            }

            else if (Position.X > FuturePosition.X)
            {
                Position = new Vector2(Position.X - Velocity.X, Position.Y);
            }

            // Change Y Coordinate
            if (Position.Y == Math.Abs(FuturePosition.Y))
            {
                Position = new Vector2(Position.X, FuturePosition.Y);
            }

            else if (Position.Y < FuturePosition.Y)
            {
                Position = new Vector2(Position.X, Position.Y + Velocity.Y);
            }

            else if (Position.Y > FuturePosition.Y)
            {
                Position = new Vector2(Position.X, Position.Y - Velocity.Y);
            }
        }

        public void SetFuturePosition(Vector2 futurePos)
        {
            if (IsSelected)
            {
                FuturePosition = futurePos;
            }
        }

        public void Update(GameTime gameTime)
        {
            // Move PC around here.
            if (Position != FuturePosition)
            {
                Move();
            }


            PlayableObjectState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // Draw PC's sprite using PlayableObject's Draw method.
            PlayableObjectState.Draw(spriteBatch, gameTime);
        }
    }
}
