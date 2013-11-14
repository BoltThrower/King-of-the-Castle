using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace King_of_the_Castle
{
    public sealed class AnimatedSpriteFactory
    {
        private static readonly AnimatedSpriteFactory instance = new AnimatedSpriteFactory();

        public ContentManager content;

        private string kingTextureName = "king";
        private string townGuardTextureName = "townGuard";
        private string banditTextureName = "bandit";

        private string attackLeft1TextureName = "attackLeft1";
        private string attackLeft2TextureName = "attackLeft2";
        private string attackRight1TextureName = "attackRight1";
        private string attackRight2TextureName = "attackRight2";

        public static AnimatedSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public AnimatedSpriteFactory()
        {
        }

        private void NonLoopingAnimation(AnimatedSprite sprite, string textureName, int textureTotalFrames, int spritesFrameInTexture, Vector2 destinationPosition)
        {
            sprite.Texture = content.Load<Texture2D>(textureName);

            int width = sprite.Texture.Width / textureTotalFrames;
            int height = sprite.Texture.Height;

            sprite.SpriteDestinationRectangle = new Rectangle((int)destinationPosition.X, (int)destinationPosition.Y, width, height);
            sprite.SpriteSourceRectangles.Add(CalculateRectangle(spritesFrameInTexture * width, 0, width, height));
        }

        private void LoopingAnimation(AnimatedSprite sprite, string textureName, int textureTotalFrames, int startingFrame, int animationTotalFrames, bool leftFacing, Vector2 destinationPosition)
        {
            sprite.Texture = content.Load<Texture2D>(textureName);

            int width = sprite.Texture.Width / textureTotalFrames;
            int height = sprite.Texture.Height;

            if (leftFacing == true)
            {
                for (int currentFrame = startingFrame; currentFrame >= animationTotalFrames || currentFrame >= 0 && currentFrame > (startingFrame - animationTotalFrames); currentFrame--)
                {
                    sprite.SpriteSourceRectangles.Add(CalculateRectangle(currentFrame * width, 0, width, height));
                }
                sprite.SpriteDestinationRectangle = new Rectangle((int)destinationPosition.X, (int)destinationPosition.Y, width, height);
            }
            else
            {
                for (int currentFrame = startingFrame; currentFrame < (animationTotalFrames + startingFrame); currentFrame++)
                {
                    sprite.SpriteSourceRectangles.Add(CalculateRectangle(width * currentFrame, 0, width, sprite.Texture.Height));
                }
                sprite.SpriteDestinationRectangle = new Rectangle((int)destinationPosition.X, (int)destinationPosition.Y, width, height);
            }
        }

        public Rectangle CalculateRectangle(int xPosition, int yPosition, int rectangleWidth, int rectangleHeight)
        {
            Rectangle calculatedRectangle = new Rectangle(xPosition, yPosition, rectangleWidth, rectangleHeight);
            return calculatedRectangle;
        }

        public AnimatedSprite BuildKingSprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, kingTextureName, 1, 0, position);
            return sprite;
        }

        public AnimatedSprite BuildTownGuardSprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, townGuardTextureName, 1, 0, position);
            return sprite;
        }

        public AnimatedSprite BuildBanditSprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, banditTextureName, 1, 0, position);
            return sprite;
        }

        // Attack Sprites

        public AnimatedSprite BuildAttackLeft1Sprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, attackLeft1TextureName, 1, 0, position);
            return sprite;
        }

        public AnimatedSprite BuildAttackLeft2Sprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, attackLeft2TextureName, 1, 0, position);
            return sprite;
        }

        public AnimatedSprite BuildAttackRight1Sprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, attackRight1TextureName, 1, 0, position);
            return sprite;
        }

        public AnimatedSprite BuildAttackRight2Sprite(Vector2 position)
        {
            AnimatedSprite sprite = new AnimatedSprite();
            NonLoopingAnimation(sprite, attackRight2TextureName, 1, 0, position);
            return sprite;
        }
    }
}
