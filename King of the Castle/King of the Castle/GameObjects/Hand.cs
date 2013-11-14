using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.GameObjects
{
    public class Hand : IHand
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public bool IsRight { get; set; }
        public bool IsActive { get; set; }

        public IHandState HandState { get; set; }

        private IPlayableObject parent;

        private int animationBuffer;
        private const int animationBufferMax = 15;

        public Hand(IPlayableObject playableObject, bool isRight, string handState)
        {
            this.parent = playableObject;
            this.IsRight = isRight;
            this.IsActive = false;

            if (handState == "AttackHand")
            {
                HandState = new AttackHand(parent, this.IsRight);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                // Animation Stuff

                if (animationBuffer >= animationBufferMax)
                {
                    HandState.IsFirstFrame = !HandState.IsFirstFrame;
                    animationBuffer = 0;
                }

                else
                {
                    animationBuffer++;
                }

                HandState.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (IsActive)
            {
                HandState.Draw(spriteBatch, gameTime);
            }
        }
    }
}
