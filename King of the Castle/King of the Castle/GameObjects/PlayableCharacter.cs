using King_of_the_Castle.Enemies;
using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace King_of_the_Castle.GameObjects
{
    public class PlayableCharacter : IPlayableObject
    {
        public Vector2 Position { get; set; }
        public Vector2 FuturePosition { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public bool IsSelected { get; set; }

        public IPlayableObjectState PlayableObjectState { get; set; }
        public IHand Hand { get; set; }

        public PlayableCharacter(Vector2 position, string characterState)
        {
            Position = position;
            FuturePosition = position;  // make the unit not move when spawned.
            Velocity = new Vector2(1f, 1f);

            IsSelected = false;
            Hand = new Hand(this, false, "AttackHand");

            if (characterState == "King")
            {
                PlayableObjectState = new King(this);
            }

            else if (characterState == "TownGuard")
            {
                PlayableObjectState = new TownGuard(this);
            }

            CollisionRectangle = PlayableObjectState.CollisionRectangle;
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


            // Update CollisionRectangle after movement
            CollisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, CollisionRectangle.Width, CollisionRectangle.Height);
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
                Hand.IsActive = false;
            }

            // Update Hand if not moving.
            else
            {
                Hand.Update(gameTime);
            }

            PlayableObjectState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // If selected, show some way that it is selected
            /*
            if (IsSelected)
            {
                
            }
             */
            // Draw PC's sprite using PlayableObject's Draw method.
            PlayableObjectState.Draw(spriteBatch, gameTime);
            Hand.Draw(spriteBatch, gameTime);
        }
    }
}
