using King_of_the_Castle.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace King_of_the_Castle.Controllers
{
    public class KeyboardController
    {
        public KeyboardController()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (Level.Instance.King.IsSelected)
                {
                    Level.Instance.King.Hand = new Hand(Level.Instance.King, false, "AttackHand");
                    Level.Instance.King.Hand.IsActive = true;
                }

                foreach (PlayableCharacter pc in Level.Instance.PlayableCharacters)
                {
                    if (pc.IsSelected)
                    {
                        pc.Hand = new Hand(pc, false, "AttackHand");
                        pc.Hand.IsActive = true;
                        break;
                    }
                }
            }
        }
    }
}
