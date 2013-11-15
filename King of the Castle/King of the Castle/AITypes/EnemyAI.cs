using King_of_the_Castle.GameObjects;
using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace King_of_the_Castle.AITypes
{
    public class EnemyAI : IAIType
    {
        private IEnemy parent;
        private bool targetSelected;
        private IPlayableObject target;

        public EnemyAI(IEnemy enemy)
        {
            parent = enemy;
        }

        private void FindTarget()
        {
            target = Level.Instance.King;
        }

        public void Move()
        {
            // Change X Coordinate
            if (parent.Position.X == Math.Abs(target.Position.X))
            {
                parent.Position = new Vector2(target.Position.X, parent.Position.Y);
            }

            else if (parent.Position.X < target.Position.X)
            {
                parent.Position = new Vector2(parent.Position.X + parent.Velocity.X, parent.Position.Y);
            }

            else if (parent.Position.X > target.Position.X)
            {
                parent.Position = new Vector2(parent.Position.X - parent.Velocity.X, parent.Position.Y);
            }

            // Change Y Coordinate
            if (parent.Position.Y == Math.Abs(target.Position.Y))
            {
                parent.Position = new Vector2(parent.Position.X, target.Position.Y);
            }

            else if (parent.Position.Y < target.Position.Y)
            {
                parent.Position = new Vector2(parent.Position.X, parent.Position.Y + parent.Velocity.Y);
            }

            else if (parent.Position.Y > target.Position.Y)
            {
                parent.Position = new Vector2(parent.Position.X, parent.Position.Y - parent.Velocity.Y);
            }


            // Update CollisionRectangle after movement
            parent.CollisionRectangle = new Rectangle((int)parent.Position.X, (int)parent.Position.Y, parent.CollisionRectangle.Width, parent.CollisionRectangle.Height);

        }

        public void Update(GameTime gameTime)
        {
            /* Move enemy towards target after finding one.
            if (!targetSelected)
            {
                FindTarget();
                targetSelected = true;
            }

            else
            {
                Move();
            }*/
        }
    }
}
