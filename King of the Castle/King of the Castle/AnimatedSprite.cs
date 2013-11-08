using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace King_of_the_Castle
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public List<Rectangle> SpriteSourceRectangles { get; set; }
        public Rectangle SpriteDestinationRectangle { get; set; }
        public int CurrentFrame { get; set; }

        public AnimatedSprite()
        {
            SpriteSourceRectangles = new List<Rectangle>();
            SpriteDestinationRectangle = new Rectangle();
            CurrentFrame = 0;
        }

        public void UpdateSpritePosition(Vector2 newPosition)
        {
            SpriteDestinationRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, SpriteDestinationRectangle.Width, SpriteDestinationRectangle.Height);
        }

        public void AdvanceFrame()
        {
            if (CurrentFrame < SpriteSourceRectangles.Count - 1)
            {
                CurrentFrame++;
            }
            else
            {
                CurrentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, SpriteDestinationRectangle, SpriteSourceRectangles[CurrentFrame], Color.White);
        }
    }
}
