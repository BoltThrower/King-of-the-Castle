using King_of_the_Castle.GameObjects;
using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace King_of_the_Castle.Controllers
{
    public class MouseController
    {
        public MouseController()
        {
        }

        private bool SelectPlayableObject(IPlayableObject playableObject, Vector2 mousePosition)
        {
            if (mousePosition.X > playableObject.CollisionRectangle.Left && mousePosition.X < playableObject.CollisionRectangle.Right && mousePosition.Y < playableObject.CollisionRectangle.Bottom && mousePosition.Y > playableObject.CollisionRectangle.Top)
            {
                playableObject.IsSelected = true;
            }

            else
            {
                playableObject.IsSelected = false;
            }

            return playableObject.IsSelected;
        }

        private void MoveSelectedPlayableObject(IPlayableObject playableObject, Vector2 mousePosition)
        {
            playableObject.SetFuturePosition(mousePosition);
        }

        public void Update(GameTime gameTime)
        {
            // Mouse selection left click and unit movement with right click.
            var mouseState = Mouse.GetState();
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                bool selectedUnit = SelectPlayableObject(Level.Instance.King, mousePosition);

                if (!selectedUnit)
                {
                    Level.Instance.King.IsSelected = false;
                    selectedUnit = SelectPlayableObject(Level.Instance.TownGuard1, mousePosition);
                }

                else
                {
                    Level.Instance.TownGuard1.IsSelected = false;
                }
            }

            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                if(Level.Instance.King.IsSelected)
                {
                    MoveSelectedPlayableObject(Level.Instance.King, mousePosition);
                }

                else if (Level.Instance.TownGuard1.IsSelected)
                {
                    MoveSelectedPlayableObject(Level.Instance.TownGuard1, mousePosition);
                }
            }
        }
    }
}
