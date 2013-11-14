using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.GameObjects
{
    public class AttackHand : IHandState
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        public bool IsRight { get; set; }
        public bool IsFirstFrame { get; set; }

        private IPlayableObject parent;
        private AnimatedSprite attackLeft1Sprite;
        private AnimatedSprite attackLeft2Sprite;
        private AnimatedSprite attackRight1Sprite;
        private AnimatedSprite attackRight2Sprite;

        public AttackHand(IPlayableObject playableObject, bool isRight)
        {
            this.parent = playableObject;
            this.IsRight = isRight;
            this.IsFirstFrame = false;

            // build the sprites.

            attackLeft1Sprite = AnimatedSpriteFactory.Instance.BuildAttackLeft1Sprite(parent.Position);
            attackLeft2Sprite = AnimatedSpriteFactory.Instance.BuildAttackLeft2Sprite(parent.Position);
            attackRight1Sprite = AnimatedSpriteFactory.Instance.BuildAttackRight1Sprite(parent.Position);
            attackRight2Sprite = AnimatedSpriteFactory.Instance.BuildAttackRight2Sprite(parent.Position);

            if (this.IsRight)
            {
                this.Position = new Vector2(parent.CollisionRectangle.Right, parent.CollisionRectangle.Top);
            }

            else
            {
                this.Position = new Vector2(parent.CollisionRectangle.Left - 16, parent.CollisionRectangle.Bottom);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.IsRight)
            {
                attackRight1Sprite.UpdateSpritePosition(new Vector2(parent.CollisionRectangle.Right - 4, parent.CollisionRectangle.Top));
                attackRight2Sprite.UpdateSpritePosition(new Vector2(parent.CollisionRectangle.Right + 2, parent.CollisionRectangle.Center.Y - 8));
            }

            else
            {
                attackLeft1Sprite.UpdateSpritePosition(new Vector2(parent.CollisionRectangle.Left - 4, parent.CollisionRectangle.Top));
                attackLeft2Sprite.UpdateSpritePosition(new Vector2(parent.CollisionRectangle.Left - 16, parent.CollisionRectangle.Center.Y - 8));
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (this.IsRight)
            {
                if (this.IsFirstFrame)
                {
                    attackRight1Sprite.Draw(spriteBatch, gameTime);
                }

                else
                {
                    attackRight2Sprite.Draw(spriteBatch, gameTime);
                }
            }

            else
            {
                if (this.IsFirstFrame)
                {
                    attackLeft1Sprite.Draw(spriteBatch, gameTime);
                }

                else
                {
                    attackLeft2Sprite.Draw(spriteBatch, gameTime);
                }
            }
        }
    }
}
